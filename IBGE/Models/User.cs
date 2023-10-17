using IBGE.ValueObjects;

namespace IBGE.Models
{
    public class User : Entity
    {
        protected User()
        {
            
        }

        public User(Email email, string password)
        {
            Email = email;
            Password = password;
            Role = "manager";
        }

        public Email Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public void CleanPassword()
        {
            Password = "";
        }
    }
}
