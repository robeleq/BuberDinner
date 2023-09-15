using BuberDinner.Application.DTOs.Auth;
using Mapster;

namespace BuberDinner.Application.Mapping
{
    public class AuthMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            /*config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);*/
            
            config.NewConfig<AuthResultDTO, AuthResponseDTO>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
