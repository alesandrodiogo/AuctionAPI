using Bogus;
using FluentAssertions;
using Leilao.API.Comunication.Request;
using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.Services;
using Leilao.API.UseCases.Auctions.GetCurrent;
using Leilao.API.UseCases.Offers.CreateOffer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {

        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();


        //ARRANGE
        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        //ACT
        var act = () => useCase.Execute(0, request);

        //ASSERT
        act.Should().NotThrow();
    }
}
