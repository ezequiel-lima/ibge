using IBGE.ValueObjects;

namespace IBGE.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public Email Email { get; set; }
        public string Password { get; set; }
    }
}
