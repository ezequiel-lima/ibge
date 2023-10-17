using IBGE.Contracts;

namespace IBGE.ValueObjects
{
    public class Email : ValueObject
    {
        protected Email()
        {
                
        }

        public Email(string address)
        {
            Address = address;

            AddNotifications(new EmailContract(this));
        }

        public string Address { get; private set; }
    }
}
