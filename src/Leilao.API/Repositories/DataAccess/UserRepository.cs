using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
    private readonly LeilaoDbContext _dbContext;
    public UserRepository(LeilaoDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
       return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email) => _dbContext.Users.First(user => user.Email.Equals(email));
}
