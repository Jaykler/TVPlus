
using TVPlus.Application.Interfaces.Repositories;
using TVPlus.Domain.Entities;
using TVPlus.Infrastructure.Context;
using TVPlus.Infrastructure.Core;



namespace TVPlus.Infrastructure.Repositories
{
    public class SeriesRepository : BaseRepository<Serie>, ISerieRepository
    {
        private readonly TVPlusContext _dbContext;

        public SeriesRepository(TVPlusContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}