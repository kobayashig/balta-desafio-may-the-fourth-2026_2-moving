using Moving.Application.Dto;
using Moving.Core.Models;

namespace Moving.Application.Extensions;

public static class ConvertToObject
{
    public static Item ConvertToItem(this ItemDtoRequest request) 
        => new Item()
        {
            Name = request.Name,
            Box = request.Box
        };
}