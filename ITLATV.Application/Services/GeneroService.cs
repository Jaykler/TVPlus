using TVPlus.Application.Interfaces.Repositories;
using TVPlus.Application.Interfaces.Services;
using TVPlus.Application.Models.Genero;
using TVPlus.Domain.Entities;

namespace TVPlus.Application.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        public async Task AddAsync(SaveGeneroModel model)
        {
            Genero genero = new();
            genero.Id = model.Id;
            genero.Name = model.Name;
            genero.Description = model.Description;

            await _generoRepository.AddAsync(genero);
        }
        public async Task UpdateAsync(SaveGeneroModel model)
        {
            Genero genero = new()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            await _generoRepository.UpdateAsync(genero);
        }

        public async Task DeleteAsync(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            await _generoRepository.DeleteAsync(genero);
        }

        public async Task<SaveGeneroModel> GetByIdSaveModel(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);

            SaveGeneroModel model = new()
            {
                Id = genero.Id,
                Name = genero.Name!,
                Description = genero.Description!
            };

            return model;
        }

        public async Task<List<GeneroModel>> GetAllModel()
        {
            var GenerosList = await _generoRepository.GetAllWithIncludeAsync(
                new List<string> {"Generos"});
            return GenerosList.Select(genero => new GeneroModel
            {
                Id = genero.Id,
                Name = genero.Name!,
                Description = genero.Description!
            }).ToList();
        }
    }
}
