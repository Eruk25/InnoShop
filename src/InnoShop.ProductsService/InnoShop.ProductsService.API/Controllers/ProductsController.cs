using System.Security.Claims;
using InnoShop.ProductsService.API.DTOs.Filters;
using InnoShop.ProductsService.API.DTOs.Requests;
using InnoShop.ProductsService.API.DTOs.Responses;
using InnoShop.ProductsService.Application.Products.Create;
using InnoShop.ProductsService.Application.Products.Delete;
using InnoShop.ProductsService.Application.Products.Filters;
using InnoShop.ProductsService.Application.Products.Get;
using InnoShop.ProductsService.Application.Products.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoShop.ProductsService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllAsync([FromBody]ProductFilterQuery request)
    {
        var filters = new ProductSearchCriteria(
            request.Search,
            request.MinPrice,
            request.MaxPrice);
        
        var products = await _mediator.Send(new GetAllProductsQuery(filters));
        var response = products.
            Select(p => new ProductResponse(
                p.Id,
                p.Title,
                p.Description,
                p.Price));
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetByIdAsync(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        var response = new ProductResponse(
            product.Id,
            product.Title,
            product.Description,
            product.Price);
        return Ok(response);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync([FromBody]CreateProductRequest request)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        await _mediator.Send(new CreateProductCommand(
            request.Title,
            request.Description,
            request.Price,
            int.Parse(userId)));
        return Ok();
    }

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody]UpdateProductRequest request)
    {
        await _mediator.Send(new UpdateProductCommand(
            id,
            request.Title,
            request.Description,
            request.Price));
        return Ok();
    }

    [Authorize(AuthenticationSchemes = "ServiceAuth")]
    [HttpPost("{id}/soft-delete")]
    public async Task<IActionResult> SoftDeleteAsync(int id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return Ok();
    }
}