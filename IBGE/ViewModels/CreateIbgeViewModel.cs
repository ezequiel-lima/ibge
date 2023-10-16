using IBGE.Contracts;
using IBGE.Models;
using System.Text.Json.Serialization;

namespace IBGE.ViewModels
{
    public class CreateIbgeViewModel : ViewModelBase
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string CodeIbge { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public Ibge MapTo()
        {
            AddNotifications(new CreateIbgeContract(this));

            return new Ibge(CodeIbge, State, City);
        }
    }
}
