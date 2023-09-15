using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BuberDinner.Application.CmdQueryHandlers.Accounts
{
    public class DeleteAccountById
    {
        public record Command(Guid userId, Guid accountId) : IRequest<ErrorOr<Unit>>;

        public class QueryHandler : IRequestHandler<Command, ErrorOr<Unit>>
        {
            private readonly IRepositoryManager _repositoryManager;
            private readonly IMapper _mapper;

            public QueryHandler(IRepositoryManager _repositoryManager, IMapper _mapper)
            {
                this._repositoryManager = _repositoryManager;
                this._mapper = _mapper;
            }

            public async Task<ErrorOr<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _repositoryManager.UserRepository.GetUserByIdAsync(request.userId, cancellationToken);
                if (user is null)
                {
                    return UserErrors.UserNotFound;
                }

                var account = await _repositoryManager.AccountRepository.GetAccountByIdAsync(request.accountId, cancellationToken);
                if (account is null)
                {
                    return AccountErrors.AccountNotFound;
                }

                if (account.AppUserId != user.Id)
                {
                    return AccountErrors.AccountDoesNotBelongToUser;
                }
                _repositoryManager.AccountRepository.DeleteAccount(account);

                await _repositoryManager.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
