

using TVPlus.Application.Interfaces.Repositories;
using TVPlus.Application.Interfaces.Services;
using TVPlus.Application.Models.Productora;
using TVPlus.Domain.Entities;

namespace TVPlus.Application.Services
{
    public class ProductoraService : IProductoraService
    {
        private readonly IProductoraRepository _productoraRepository;
        public ProductoraService(IProductoraRepository productoraRepository)
        {
            _productoraRepository = productoraRepository;
        }
        public async Task AddAsync(SaveProductoraModel model)
        {
            Productora productora = new();
            productora.Id = model.Id;
            productora.Name = model.Name;
            productora.Description = model.Description;

            await _productoraRepository.AddAsync(productora);
        }

        public async Task DeleteAsync(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);
            await _productoraRepository.DeleteAsync(productora);
        }

        public async Task<List<ProductoraModel>> GetAllModel()
        {
           var productoraList =await _productoraRepository.GetAllWithIncludeAsync(new List<string> {"Productoras"});
            return productoraList.Select(p => new ProductoraModel
            {
                Id = p.Id,
                Name =  p.Name!,
                Description = p.Description!
            }).ToList();
        }

        public async Task<SaveProductoraModel> GetByIdSaveModel(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);

            SaveProductoraModel model = new ();
            model.Id = productora.Id;
            model.Name = productora.Name!;
            model.Description = productora.Description!;
            
            return model;
        }

        public async Task UpdateAsync(SaveProductoraModel model)
        {
           Productora productora =new();
            productora.Id = model.Id;
            productora.Name = model.Name;
            productora.Description = model.Description;
            await _productoraRepository.UpdateAsync(productora);
        }
    }
}
