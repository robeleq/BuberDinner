using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.DTOs.UserProfiles;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace BuberDinner.Application.CmdQueryHandlers.UserProfiles
{
    public class GetUserProfileByUserId
    {
        public record Query(Guid userId) : IRequest<ErrorOr<UserProfileResponseDto>>;

        public class QueryHandler : IRequestHandler<Query, ErrorOr<UserProfileResponseDto>>
        {
            private readonly IRepositoryManager _repositoryManager;
            private readonly IMapper _mapper;

            public QueryHandler(IRepositoryManager repositoryManager, IMapper mapper)
            {
                this._repositoryManager = repositoryManager;
                this._mapper = mapper;
            }

            public async Task<ErrorOr<UserProfileResponseDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var profile = await _repositoryManager.UserProfileRepository.GetUserProfileByUserIdAsync(request.userId, cancellationToken);
                
                if (profile is null)
                {
                    return UserErrors.UserNotFound;
                }

                return _mapper.Map<UserProfileResponseDto>(profile);
            }
        }
    }
}
