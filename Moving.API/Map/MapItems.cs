using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moving.Application.Dto;
using Moving.Application.Services.Abstraction;
using Moving.Infra.Services;

namespace Moving.API.Map;

public static class MapItems
{
    public static WebApplication AddMap(this WebApplication app)
    {
        app.MapGet();
        app.MapPost();
        
        return app;
    }

    extension(WebApplication app)
    {
        private void MapGet()
        {
            app.MapGet("/items/{itemName}", async (
                   [FromRoute]string itemName,
                   IItemServiceApplication itemService,
                   CancellationToken ct) =>
               {
                   var box = await itemService.GetItemAsync(itemName, ct);

                   return box;
               })
               .WithName("GetItem");
            
            app.MapGet("/items", async (CancellationToken ct, 
                    IItemServiceApplication itemService) =>
               {
                   var items = await itemService.GetAllAsync(ct);

                   return items;
               })
            .WithName("GetItems");
        }

        private void MapPost()
        { 
            app.MapPost("/item", async (
                   [FromBody]
                   ItemDtoRequest request,
                   IItemServiceApplication itemService,
                   CancellationToken ct) =>
               {
                   await itemService.PostItemAsync(request, ct);
               })
               .WithName("PostItem");
        }
    }
}