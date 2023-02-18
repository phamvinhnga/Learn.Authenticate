using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Entity.Migrations;
using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Shared.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using static Learn.Authenticate.Shared.Common.CoreEnum;

namespace Learn.Authenticate.Biz.Managers
{
    public class FileManager : IFileManager
    {
        private string _uploadDirecotroy = string.Empty;
        private string _url = string.Empty;
        private IConfiguration _configuration;

        public FileManager(
            IConfiguration configuration
        ) 
        {
            _configuration = configuration;
            _uploadDirecotroy = _configuration.GetSection("Upload:Folder").Value;
            _url = _configuration.GetSection("Upload:Url").Value;
        }

        public string BuidlFileContent(string input, Folder folder)
        {
            if (input == null)
            {
                return null;
            }

            var reg = "\"data:([^;]*);base64,([^\"]*)\"";
            var matches = Regex.Matches(input, reg, RegexOptions.IgnoreCase);
            foreach (Match item in matches)
            {
                var path = $"{_uploadDirecotroy}\\";
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path);
                {
                    path += folder;
                    uploadPath = Path.Combine(uploadPath, folder.ToString());
                }
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var base64String = item.Groups[2].Value;
                byte[] fileBytes = Convert.FromBase64String(base64String);
                var id = $"no_name_{Guid.NewGuid()}{GetTypeImage(item.Groups[0].Value)}".Replace("-", "_");
                using (var fs = new FileStream($"{uploadPath}\\{id}", FileMode.Create))
                {
                    fs.Write(fileBytes, 0, fileBytes.Length);
                }
                input = input.Replace(item.Value, string.Format(_url, folder, id));
            }

            return input;
        }

        public FileModel Upload(IFormFile file, Folder folder)
        {
            if(file == null)
            {
                return null;
            }

            var result = new FileModel();

            if (string.IsNullOrEmpty(file.FileName))
            {
                result.Id = $"no_name_{Guid.NewGuid()}".Replace("-", "_");
                result.Name = null;
            }
            else
            {
                result.Id = $"{Guid.NewGuid()}_{file.FileName}".Replace(" ", "_").Replace("-", "_").ConvertVietnameseToEnglish();
                result.Name = file.FileName;
            }

            var path = $"{_uploadDirecotroy}\\";

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path);
            {
                path += folder;
                uploadPath = Path.Combine(uploadPath, folder.ToString());
            }

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath = Path.Combine(uploadPath, result.Id);
            using (var strem = File.Create(filePath))
            {
                file.CopyTo(strem);
            }

            result.Url = string.Format(_url, folder, result.Id);
            result.Type = file.ContentType;
            return result;
        }

        public FileModel Upload(FileModel file, Folder folder)
        {
            if (file == null)
            {
                return null;
            }

            var result = new FileModel();

            if (string.IsNullOrEmpty(file.Name))
            {
                result.Id = $"no_name_{Guid.NewGuid()}".Replace("-", "_");
                result.Name = null;
            }
            else
            {
                result.Id = $"{Guid.NewGuid()}_{file.Name}".Replace(" ", "_").Replace("-", "_").ConvertVietnameseToEnglish();
                result.Name = file.Name;
            }

            var path = $"{_uploadDirecotroy}\\";

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), path);
            {
                path += folder;
                uploadPath = Path.Combine(uploadPath, folder.ToString());
            }

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            byte[] fileBytes = Convert.FromBase64String(file.Url);
            using (var fs = new FileStream($"{uploadPath}\\{result.Id}", FileMode.Create))
            {
                fs.Write(fileBytes, 0, fileBytes.Length);
            }
            result.Url = string.Format(_url, folder, result.Id);
            return result;
        }

        private string GetTypeImage(string base64String)
        {
            if (base64String.Contains("data:image/png;base64,"))
            {
                return ".png";
            }
            else if (base64String.Contains("data:image/jpeg;base64,"))
            {
                return ".jpg";
            }
            else if (base64String.Contains("data:image/jpg;base64,"))
            {
                return ".jpg";
            }
            else if (base64String.Contains("data:image/gif;base64,"))
            {
                return ".gif";
            }
            return string.Empty;
        }
    }
}
