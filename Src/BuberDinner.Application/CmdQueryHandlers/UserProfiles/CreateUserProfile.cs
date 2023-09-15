using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Application.DTOs.UserProfiles;
using BuberDinner.Application.Errors;
using BuberDinner.Application.Interfaces;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BuberDinner.Application.CmdQueryHandlers.UserProfiles
{
    public class CreateUserProfile
    {
        public record Command(
            Guid UserId,
            string FirstName,
            string LastName,
            string PhoneNumber,
            string City,
            string Address,
            string State) : IRequest<ErrorOr<UserProfileResponseDto>>;

        public class CommandHandler : IRequestHandler<Command, ErrorOr<UserProfileResponseDto>>
        {
            private readonly UserManager<IdentityUser> _userManager;

            private readonly IRepositoryManager _repositoryManager;

            private readonly IMapper _mapper;

            public CommandHandler(UserManager<IdentityUser> userManager, IRepositoryManager repositoryManager, IMapper mapper)
            {
                _repositoryManager = repositoryManager;
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<ErrorOr<UserProfileResponseDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                {
                    return UserErrors.UserNotFound;
                }

                // Create a new Account 
                var profile = new UserProfile
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    City = request.City,
                    Address = request.Address,
                    State = request.State,
                };
                profile.User = user;

                _repositoryManager.UserProfileRepository.CreateUserProfile(profile);

                await _repositoryManager.SaveChangesAsync(cancellationToken);

                return _mapper.Map<UserProfileResponseDto>(profile);
            }
        }
    }
}
