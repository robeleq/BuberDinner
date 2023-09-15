using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.DTOs.Accounts
{
    public class AccountResultDTO
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string AccountType { get; set; }

        public Guid UserId { get; set; }
    }
}
