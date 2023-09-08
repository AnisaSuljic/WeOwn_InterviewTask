namespace WeOwnAPI.ValueObjects
{
    public class Rating
    {
        public string Value { get; }

        public Rating(string value)
        {
            Value = value;
        }
    }
}
