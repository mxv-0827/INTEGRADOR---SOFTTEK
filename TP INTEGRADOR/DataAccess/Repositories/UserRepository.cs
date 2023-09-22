using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.DTOs;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Helpers;
using TP_INTEGRADOR.Infrastructure;

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
                userToUpdate.Password = PasswordEncrypter_Helper.EncryptPassword(entity.Password, userToUpdate.DNI);
                userToUpdate.UserRole = entity.UserRole;
                userToUpdate.LeavingDate = entity.LeavingDate;

                return true;
            }

            return false;
        }

        //Verifica que coincida el ID y la PASSWORD para un correcto login.
        public async Task<object?> AuthenticateCredentials(AuthenticateDTO userToAuthenticate)
        {
            var user = await GetById(userToAuthenticate.ID); //Si el ID existe, quiero que me devuelva el DNI del usuario para pasarlo como parametro al 'EncryptPassword' y usarlo como SALT.

            if (user != null) 
            {
                if (user.LeavingDate != null) return ResponseFactory.CreateErrorResponse(404, "User has been deactivated.");

                var credentials = await _dbContext.Users.SingleOrDefaultAsync(x => x.CodUser == userToAuthenticate.ID && x.Password == PasswordEncrypter_Helper.EncryptPassword(userToAuthenticate.Password, user.DNI));
                if (credentials == null) return ResponseFactory.CreateErrorResponse(404, "Incorrect Credentials");

                return credentials;
            }

            return ResponseFactory.CreateErrorResponse(404, "ID not found");
        }
    }
}
