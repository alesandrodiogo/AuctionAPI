using Leilao.API.Entities;
using Leilao.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leilao.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new LeilaoDbContext();

        var today = DateTime.Now;
        //var today = new DateTime(202, 05, 01);

        return repository
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts || today <= auction.Ends);
            //.FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}
