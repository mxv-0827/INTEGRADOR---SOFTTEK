using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.DTOs;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public override async Task<bool> Update(User entity, int id)
        {
            var userToUpdate = await _dbContext.Set<User>().FirstOrDefaultAsync(x => x.CodUser == id);

            if (userToUpdate != null)
            {
                userToUpdate.Name = entity.Name;
                userToUpdate.DNI = entity.DNI;
                userToUpdate.Password = entity.Password;
                userToUpdate.UserRole = entity.UserRole;

                return true;
            }

            return false;
        }

        //Verifica que coincida el ID y la PASSWORD para un correcto login.
        public async Task<User?> AuthenticateCredentials(AuthenticateDTO userToAuthenticate)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.CodUser == userToAuthenticate.ID && x.Password == userToAuthenticate.Password);
        }
    }
}
