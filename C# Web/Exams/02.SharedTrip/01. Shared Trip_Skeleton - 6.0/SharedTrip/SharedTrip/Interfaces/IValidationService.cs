using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Interfaces
{
    public interface IValidationService
    {
        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(object model);
    }
}
