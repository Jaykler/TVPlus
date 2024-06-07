
namespace TVPlus.Application.Interfaces.Services
{
    public interface IBaseServices
    {
        public interface IBaseServices<SaveModel, Model>
        where SaveModel : class
        where Model : class

        {
            Task AddAsync(SaveModel model);
            Task UpdateAsync(SaveModel model);
            Task DeleteAsync(int id);
            Task<SaveModel> GetByIdSaveModel(int id);
            Task<List<Model>> GetAllModel();
        }
    }
}
