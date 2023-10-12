using IBGE.Models;

namespace IBGE.ViewModels
{
    public class CreateIbgeViewModel
    {
        public string Id { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public Ibge MapTo()
        {
            return new Ibge(Id, State, City);
        }
    }
}
