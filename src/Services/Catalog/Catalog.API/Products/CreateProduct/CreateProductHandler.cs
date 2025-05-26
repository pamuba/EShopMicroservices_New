﻿namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description,
        string ImageFile, decimal Price):ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler (IDocumentSession session) 
        : ICommandHandler<CreateProductCommand, CreateProductResult>
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
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //return CreateProductResult result
            return new CreateProductResult(product.Id);
        }
    }
}

//MediatR = Interfaces / Abstraction Layer =  CQRS

//IRequest    IRequest
//ICommand    IQuery

//IRequestHandler   IRequestHandler
//ICommandHAndler   IQueryHandler