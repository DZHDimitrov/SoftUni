namespace SMS.Interfaces
{
    public interface IValidationService
    {
        public (bool isValid, string error) ValidateModel(object model);
    }
}
