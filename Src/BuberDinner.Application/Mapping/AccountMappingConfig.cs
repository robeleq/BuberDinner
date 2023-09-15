using BuberDinner.Application.CmdQueryHandlers.Accounts;
using BuberDinner.Application.DTOs.Accounts;
using BuberDinner.Domain.Entities;
using Mapster;

namespace BuberDinner.Application.Mapping
{
    public class AccountMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        { 
            config.NewConfig<Account, AccountResultDTO>()                
                .Map(dest => dest, src => src);

            config.NewConfig<AccountResultDTO, AccountResponseDTO>()
                .Map(dest => dest, src => src);

            config.NewConfig<(Guid, Guid), GetAccountById.Query>()
                .Map(dest => dest.userId, src => src.Item1)
                .Map(dest => dest.accountId, src => src.Item2);

            config.NewConfig<(Guid, Guid), DeleteAccountById.Command>()
               .Map(dest => dest.userId, src => src.Item1)
               .Map(dest => dest.accountId, src => src.Item2);
        }
    }
}
