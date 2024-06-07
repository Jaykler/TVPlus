
using TVPlus.Application.Interfaces.Repositories;
using TVPlus.Application.Interfaces.Services;
using TVPlus.Application.Models.Serie;
using TVPlus.Domain.Entities;

namespace TVPlus.Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;
        public SerieService(ISerieRepository serieRepository)
        {
            _serieRepository = serieRepository;
        }

        public async Task AddAsync(SaveSerieModel model)
        {
            Serie serie = new();
            serie.Id = model.Id;
            serie.Name = model.Name;
            serie.Description = model.Description;

            await _serieRepository.AddAsync(serie);
        }

        public async Task DeleteAsync(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            await _serieRepository.DeleteAsync(serie);
        }

        public async Task<List<SerieModel>> GetAllModel()
        {
            var SeriesList = await _serieRepository.GetAllWithIncludeAsync(new List<string> { "Series" });
            return SeriesList.Select(serie => new SerieModel 
            { 
                Id = serie.Id,
                Name = serie.Name!,
                Description = serie.Description!
            }).ToList();
        }

        public async Task<SaveSerieModel> GetByIdSaveModel(int id)
        {
            var serie = await _serieRepository.GetByIdAsync(id);
            SaveSerieModel model = new ();
            model.Id = serie.Id;
            model.Name = serie.Name!;
            model.Description = serie.Description!;

            return model;
        }

        public async Task UpdateAsync(SaveSerieModel model)
        {
            Serie serie = new();
            serie.Id = model.Id;
            serie.Name = model.Name;
            serie.Description = model.Description;

            await _serieRepository.UpdateAsync(serie);
        }
    }
}
