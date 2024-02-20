using Leilao.API.Entities;
using Leilao.API.Repositories.DataAccess;

namespace Leilao.API.Contracts;

public interface IUserRepository
{
    bool ExistUserWithEmail(string email);
    User GetUserByEmail(string email);
}
