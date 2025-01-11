﻿using Domain.Entities;
using MediatR;

namespace Application.Recipes.Commands.CreateRecipe;
public class CreateRecipeCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public IEnumerable<Instruction>? Instructions { get; set; }
}
