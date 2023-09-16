using TP_INTEGRADOR.DataAccess;
using TP_INTEGRADOR.DataAccess.Repositories;

namespace TP_INTEGRADOR.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;

        public UserRepository UserRepository { get; private set; }
        public ProjectRepository ProjectRepository { get; private set; }
        public ServiceRepository ServiceRepository { get; private set; }
        public WorkRepository WorkRepository { get; private set; }
        public RoleRepository RoleRepository { get; private set; }


        public UnitOfWorkService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new UserRepository(_dbContext);
            ProjectRepository = new ProjectRepository(_dbContext);
            ServiceRepository = new ServiceRepository(_dbContext);
            WorkRepository = new WorkRepository(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Task<int> Save()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
