using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.CmdQueryHandlers.Accounts
{
    public class CreateAccount
    {
        public record Command(Guid UserId, string AccountType, DateTime DateCreated) : IRequest<ErrorOr<AccountResultDTO>>;

        public class CommandHandler : IRequestHandler<Command, ErrorOr<AccountResultDTO>>
        {
            private readonly IRepositoryManager _repositoryManager;
            private readonly IMapper _mapper;

            public CommandHandler(IRepositoryManager _repositoryManager, IMapper _mapper)
            {
                this._repositoryManager = _repositoryManager;
                this._mapper = _mapper;
            }

            public async Task<ErrorOr<AccountResultDTO>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _repositoryManager.UserRepository.GetUserByIdAsync(request.UserId, cancellationToken);

                if (user is null)
                {
                    return UserErrors.UserNotFound;
                }

                // Create a new Account 
                var account = new Account
                {
                    AccountType = request.AccountType,
                    DateCreated = request.DateCreated,
                };
                account.AppUserId = user.Id;

                _repositoryManager.AccountRepository.CreateAccount(account);

                await _repositoryManager.SaveChangesAsync(cancellationToken);

                return _mapper.Map<AccountResultDTO>(account);
            }
        }
    }
}
