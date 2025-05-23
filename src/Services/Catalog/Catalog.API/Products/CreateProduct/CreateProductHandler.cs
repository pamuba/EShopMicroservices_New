using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description,
        string ImageFile, decimal Price):ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {

            //create a Product Entity from the Command Object
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };

            //save to database

            //return CreateProductResult result
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}

//MediatR = Interfaces / Abstraction Layer =  CQRS

//IRequest    IRequest
//ICommand    IQuery

//IRequestHandler   IRequestHandler
//ICommandHAndler   IQueryHandler