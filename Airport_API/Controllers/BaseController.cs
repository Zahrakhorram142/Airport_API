﻿using Airport.Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Airport_API.Controllers
{
    [Route("api/V{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase

    {
        //Shared Code
        //Logger
        //CQRS Pattern,MediatR

        private ISender _mediator;
        private ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        private async Task<ObjectResult> SendAsync<T>(IRequest<Response<T>> request, CancellationToken ct = default)
        {
            var result = await Mediator.Send(request, ct);

            if (result.Succeeded)
                return Ok(result);

            return Ok(result);

        }

        protected async Task<ObjectResult> SendAsync(IRequest<Response<object>> request, CancellationToken ct = default)
            => await SendAsync<object>(request, ct);

        protected async Task<ObjectResult> SendAsync(IRequest<Response<Guid>> request, CancellationToken ct = default)
            => await SendAsync<Guid>(request, ct);

        protected async Task<ObjectResult> SendAsync(IRequest<Response<int>> request, CancellationToken ct = default)
            => await SendAsync<int>(request, ct);

        protected async Task<ObjectResult> SendAsync(IRequest<Response<long>> request, CancellationToken ct = default)
            => await SendAsync<long>(request, ct);

    }
}
