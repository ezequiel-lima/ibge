using IBGE.Contracts;
using IBGE.Models;

namespace IBGE.ViewModels
{
    public class UpdateIbgeViewModel : ViewModelBase
    {
        public string CodeIbge { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public Ibge MapTo()
        {
            AddNotifications(new UpdateIbgeContract(this));

            return new Ibge(CodeIbge, State, City);
        }
    }
}
