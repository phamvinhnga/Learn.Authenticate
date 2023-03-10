using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Authenticate.Biz.Managers.Interfaces
{
    public interface IFileManager
    {
        string BuidlFileContent(string input, CoreEnum.Folder folder);
        FileModel Upload(IFormFile file, CoreEnum.Folder folder);
        FileModel Upload(FileModel file, CoreEnum.Folder folder);
    }
}
