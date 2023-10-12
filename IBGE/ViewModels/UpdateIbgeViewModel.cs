using IBGE.Models;

namespace IBGE.ViewModels
{
    public class UpdateIbgeViewModel
    {
        public string State { get; set; }
        public string City { get; set; }

        public Ibge MapTo()
        {
            return new Ibge(State, City);
        }
    }
}
