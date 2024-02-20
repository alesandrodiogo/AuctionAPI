using Leilao.API.Entities;

namespace Leilao.API.Contracts;

public interface IOfferRepository
{
     void Add(Offer offer);
}
