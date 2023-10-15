namespace IBGE.Models
{
    public class User : Entity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }

        public void CleanPassword()
        {
            Password = "";
        }
    }
}
