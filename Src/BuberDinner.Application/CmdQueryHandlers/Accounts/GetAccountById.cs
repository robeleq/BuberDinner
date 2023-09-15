using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BuberDinner.Application.CmdQueryHandlers.Accounts
{
    public class GetAccountById
    {
        public record Query(Guid userId, Guid accountId) : IRequest<ErrorOr<AccountResultDTO>>;

        public class QueryHandler : IRequestHandler<Query, ErrorOr<AccountResultDTO>>
        {
            private readonly IRepositoryManager _repositoryManager;
            private readonly IMapper _mapper;

            public QueryHandler(IRepositoryManager _repositoryManager, IMapper _mapper)
            {
                this._repositoryManager = _repositoryManager;
                this._mapper = _mapper;
            }

            public async Task<ErrorOr<AccountResultDTO>> Handle(Query request, CancellationToken cancellationToken)
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

                var accountResultDto = _mapper.Map<AccountResultDTO>(account);

                return accountResultDto;
            }
        }
    }
}
