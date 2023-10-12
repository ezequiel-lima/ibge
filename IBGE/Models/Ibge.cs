using IBGE.ViewModels;

namespace IBGE.Models
{
    public class Ibge
    {
        public Ibge(string id, string state, string city)
        {
            Id = id;
            State = state;
            City = city;
        }

        public Ibge(string state, string city)
        {
            State = state;
            City = city;
        }

        public string Id { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }

        public void Change(UpdateIbgeViewModel model)
        {
            State = model.State;
            City = model.City;
        }
    }
}
