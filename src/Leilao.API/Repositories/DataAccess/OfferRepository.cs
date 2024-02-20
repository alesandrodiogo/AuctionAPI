using Leilao.API.Contracts;
using Leilao.API.Entities;

namespace Leilao.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository
{
    private readonly LeilaoDbContext _dbContext;
    public OfferRepository(LeilaoDbContext dbContext) => _dbContext = dbContext;
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();
    }
}
