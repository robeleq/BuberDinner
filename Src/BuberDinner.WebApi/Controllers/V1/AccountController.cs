using BuberDinner.Application.CmdQueryHandlers.Accounts;
using BuberDinner.Application.CmdQueryHandlers.Auth;
using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Domain.Entities;
using BuberDinner.WebApi.Controllers;
using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnionArch.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users/{userId:guid}/accounts")]
    public class AccountController : BaseApiController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetAllAccountsByUserId.Query(userId);

            IEnumerable<AccountResultDTO> results = await _mediator.Send(query);

            return Ok(_mapper.Map<IEnumerable<AccountResultDTO>>(results));
        }

        [HttpGet("{accountId:guid}")]
        public async Task<IActionResult> GetAccountById(Guid userId, Guid accountId, CancellationToken cancellationToken)
        {
            // var query = _mapper.Map<GetAccountById.Query>(userId, accountId);

            // var query = (userId, accountId).Adapt<(Guid, Guid), GetAccountById.Query>();

            var query = new GetAccountById.Query(userId, accountId);

            ErrorOr<AccountResultDTO> result = await _mediator.Send(query);

            return result.Match(
               result => Ok(_mapper.Map<AccountResponseDTO>(result)),
               errors => Problem(errors));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAccount(Guid userId, [FromBody] AccountCreateRequestDTO request, CancellationToken cancellationToken)
        {          
            var command = new CreateAccount.Command(userId, request.AccountType, request.DateCreated);

            ErrorOr<AccountResultDTO> result = await _mediator.Send(command);

            return result.Match(
                result => Ok(_mapper.Map<AccountResponseDTO>(result)),
                errors => Problem(errors));
        }
        
        [HttpDelete("{accountId:guid}")]
        public async Task<IActionResult> DeleteAccount(Guid userId, Guid accountId, CancellationToken cancellationToken)
        {
            var command = (userId, accountId).Adapt<DeleteAccountById.Command>();
            
            ErrorOr<Unit> result = await _mediator.Send(command);
            // ErrorOr<Unit> result = await _mediator.Send(new DeleteAccountById.Command(userId, accountId));

            return result.Match(
               result => NoContent(),
               errors => Problem(errors));
        }
    }
}
