
namespace BuberDinner.Domain.Entities;

public class AppUser
{
    public AppUser()
    {
        Accounts = new HashSet<Account>();
    }

    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public ICollection<Account> Accounts { get; private set; }
}
