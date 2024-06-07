
using TVPlus.Application.Models.Genero;
using static TVPlus.Application.Interfaces.Services.IBaseServices;

namespace TVPlus.Application.Interfaces.Services
{
    public interface IGeneroService : IBaseServices<SaveGeneroModel, GeneroModel>
    {
    }
}
