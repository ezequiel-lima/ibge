using Flunt.Validations;
using IBGE.ViewModels;
using System.Text.RegularExpressions;

namespace IBGE.Contracts
{
    public class UpdateIbgeContract : Contract<UpdateIbgeViewModel>
    {
        public UpdateIbgeContract(UpdateIbgeViewModel model)
        {
            AcceptsOnlyWholeNumbers(model);

            Requires()
                .IsNotNullOrEmpty(model.City, "City", "City field cannot be empty or null")
                .IsNotNullOrEmpty(model.State, "State", "State field cannot be be empty or null")
                .IsNotNullOrEmpty(model.CodeIbge, "CodeIbge", "CodeIbge field cannot be empty or null")
                .IsLowerOrEqualsThan(model.City, 80, "City field can contain a maximum of 80 characters")
                .AreEquals(model.State, 2, "State field must contain exactly 2 characters")
                .AreEquals(model.CodeIbge, 7, "CodeIbge field must contain exactly 7 characters");
        }

        private void AcceptsOnlyWholeNumbers(UpdateIbgeViewModel model)
        {
            if (!Regex.IsMatch(model.CodeIbge ?? "", @"^\d+$"))
                AddNotification("CodeIbge", "Invalid IBGE code");
        }
    }
}
