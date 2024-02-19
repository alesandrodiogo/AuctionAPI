using Leilao.API.Comunication.Request;
using Leilao.API.Filters;
using Leilao.API.UseCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace Leilao.API.Controllers;

[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : LeilaoAPIBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId, [FromBody]
        RequestCreateOfferJson request,
        CreateOfferUseCase useCase)
     { 
      var id =  useCase.Execute(itemId, request);
        return Created(string.Empty, id);
    }
}
