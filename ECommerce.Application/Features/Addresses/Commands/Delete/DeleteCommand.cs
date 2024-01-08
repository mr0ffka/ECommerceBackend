﻿using MediatR;

namespace ECommerce.Application.Features.Addresses.Commands.Delete
{
    public class DeleteCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
