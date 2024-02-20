using Leilao.API.Entities;

namespace Leilao.API.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
