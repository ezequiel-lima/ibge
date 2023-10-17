using Flunt.Validations;
using IBGE.ValueObjects;

namespace IBGE.Contracts
{
    public class EmailContract : Contract<Email>
    {
        public EmailContract(Email model)
        {
            Requires()
                .IsEmail(model.Address, "Email.Address", "Invalid e-mail");
        }
    }
}
