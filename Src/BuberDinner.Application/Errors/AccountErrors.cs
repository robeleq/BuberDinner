using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Errors
{
    public static class AccountErrors
    {
        public static Error AccountNotFound => Error.NotFound(
           code: "Account.AccountNotFound",
           description: "Account does not exist.");

        public static Error AccountDoesNotBelongToUser => Error.Validation(
           code: "Account.AccountDoesNotBelongToUser",
           description: "Account Does Not Belong To User.");
    }
}
