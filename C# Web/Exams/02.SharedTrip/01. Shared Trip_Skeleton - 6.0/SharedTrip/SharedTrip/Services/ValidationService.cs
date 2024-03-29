﻿namespace SharedTrip.Services
{
    using SharedTrip.Interfaces;
    using SharedTrip.ViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ValidationService : IValidationService
    {
        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, null);
            }

            return (isValid, errorResult.Select(e => new ErrorViewModel() { ErrorMessage = e.ErrorMessage}));
        }
    }
}
