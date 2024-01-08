﻿using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Delete
{
    public class DeleteCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
