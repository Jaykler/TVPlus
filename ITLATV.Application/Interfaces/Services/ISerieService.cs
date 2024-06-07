
using TVPlus.Application.Models.Serie;
using static TVPlus.Application.Interfaces.Services.IBaseServices;

namespace TVPlus.Application.Interfaces.Services
{
    public interface ISerieService : IBaseServices<SaveSerieModel,SerieModel>
    {
    }
}
