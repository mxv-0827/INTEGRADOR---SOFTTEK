using TP_INTEGRADOR.DataAccess.Repositories;

namespace TP_INTEGRADOR.Services
{
    public interface IUnitOfWork : IDisposable
    {
        public UserRepository UserRepository { get; }
        public ProjectRepository ProjectRepository { get; }
        public ServiceRepository ServiceRepository { get; }
        public WorkRepository WorkRepository { get; }
        public RoleRepository RoleRepository { get; }

        Task<int> Save();
    }
}
