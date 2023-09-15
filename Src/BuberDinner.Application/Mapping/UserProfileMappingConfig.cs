using BuberDinner.Application.DTOs.Auth;
using BuberDinner.Application.DTOs.UserProfiles;
using BuberDinner.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Mapping
{
    public class UserProfileMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserProfile, UserProfileResponseDto>()
                .Map(dest => dest.UserId, src => src.User.Id)
                .Map(dest => dest, src => src);
        }
    }
}
