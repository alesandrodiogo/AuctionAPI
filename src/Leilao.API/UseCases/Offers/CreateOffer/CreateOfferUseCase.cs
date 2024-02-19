using Leilao.API.Comunication.Request;
using Leilao.API.Entities;
using Leilao.API.Repositories;
using Leilao.API.Services;
using Microsoft.AspNetCore.Components;

namespace Leilao.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;
    public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;
    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var repository = new LeilaoDbContext();
        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id,
        };

        repository.Offers.Add(offer);
        repository.SaveChanges();

        return offer.Id;
    }
}
