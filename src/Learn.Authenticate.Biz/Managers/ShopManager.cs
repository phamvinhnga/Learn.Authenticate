using AutoMapper;
using Learn.Authenticate.Biz.Managers.Interfaces;
using Learn.Authenticate.Entity.Entities;
using Learn.Authenticate.Entity.Model;
using Learn.Authenticate.Entity.Repositories.Interfaces;
using Learn.Authenticate.Shared.Exceptions;
using Learn.Authenticate.Shared.Extensions;
using static Learn.Authenticate.Shared.Common.CoreEnum;

namespace Learn.Authenticate.Biz.Managers
{
    public class ShopManager : IShopManager
    {
        private readonly IShopRepository _shopRepository;
        private readonly IFileManager _fileManager;
        private readonly IMapper _mapper;

        public ShopManager(
            IShopRepository ShopRepository,
            IFileManager fileManager,
            IMapper mapper
        )
        {
            _shopRepository = ShopRepository;
            _fileManager = fileManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(ShopInputModel input, int userId)
        {
            var entity = _mapper.Map<Shop>(input);
            entity.SetCreateDefault(userId);
            if (input.Thumbnail != null && string.IsNullOrEmpty(input.Thumbnail.Id))
            {
                var file = _fileManager.Upload(input.Thumbnail, Folder.Shop);
                entity.Thumbnail = file.ConvertToJson();
            }
            else
            {
                entity.Thumbnail = null;
            }
            await _shopRepository.CreateAsync(entity);
        }

        public async Task UpdateAsync(ShopInputModel input, int userId)
        {
            var entity = await _shopRepository.GetByIdAsync(input.Id);
            if (entity == null)
            {
                throw new BadRequestException($"Cannot find ShopId {input.Id}");
            }
            entity = _mapper.Map<Shop>(input);
            entity.SetModifyDefault(userId);
            if (input.Thumbnail != null && string.IsNullOrEmpty(input.Thumbnail.Id))
            {
                var file = _fileManager.Upload(input.Thumbnail, Folder.Shop);
                entity.Thumbnail = file.ConvertToJson();
            }
            else
            {
                entity.Thumbnail = null;
            }
            await _shopRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _shopRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new BadRequestException($"Cannot find ShopId {id}");
            }
            await _shopRepository.DeleteAsync(entity);
        }

        public async Task<ShopOutputModel> GetByIdAsync(int id)
        {
            var query = await _shopRepository.GetByIdAsync(id);
            if (query == null)
            {
                throw new BadRequestException($"Cannot find ShopId {id}");
            }
            return _mapper.Map<ShopOutputModel>(query);
        }

        public async Task<BasePageOutputModel<ShopOutputModel>> GetListAsync(ShopPageInputModel input)
        {
            var query = await _shopRepository.GetListAsync(input);
            return new BasePageOutputModel<ShopOutputModel>(query.TotalItem, _mapper.Map<List<ShopOutputModel>>(query.Items));
        }
    }
}
