namespace FootballManager.Services
{
    using FootballManager.Interfaces;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ValidationService : IValidationService
    {
        public bool ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            return isValid;
        }
    }
}
