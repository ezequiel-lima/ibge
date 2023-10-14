using IBGE.ViewModels;

namespace IBGE.Models
{
    public class Ibge : Entity
    {
        protected Ibge() { }

        public Ibge(string codeIbge, string state, string city)
        {
            CodeIbge = codeIbge;
            State = state;
            City = city;
        }

        public string CodeIbge { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }     

        public void Change(UpdateIbgeViewModel model)
        {
            CodeIbge = model.CodeIbge;
            State = model.State;
            City = model.City;          
        }
    }
}
