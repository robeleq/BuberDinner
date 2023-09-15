using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.Interfaces;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BuberDinner.Application.CmdQueryHandlers.Accounts
{
    public class GetAllAccountsByUserId
    {
        public record Query(Guid userId) : IRequest<IEnumerable<AccountResultDTO>>;

        public class QueryHandler : IRequestHandler<Query, IEnumerable<AccountResultDTO>>
        {
            private readonly IRepositoryManager _repositoryManager;
            private readonly IMapper _mapper;

            public QueryHandler(IRepositoryManager _repositoryManager, IMapper _mapper)
            {
                this._repositoryManager = _repositoryManager;
                this._mapper = _mapper;
            }

            public async Task<IEnumerable<AccountResultDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var accounts = await _repositoryManager.AccountRepository.GetAllAccountsByUserIdAsync(request.userId, cancellationToken);

                var accountsResultDto = _mapper.Map<IEnumerable<AccountResultDTO>>(accounts);

                return accountsResultDto;
            }
        }
    }
}
