namespace WeOwnAPI.Helpers
{
    public class AddressValidationException : Exception
    {
        public AddressValidationException(string message) : base(message)
        {
        }
    }
}
