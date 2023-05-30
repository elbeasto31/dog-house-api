namespace DogHouseApi.Constants
{
    public static class ExceptionMessages
    {
        public const string AttributeDoesNotExist = "Wrong sort attribute:";
        public const string DogAlreadyExists = "The dog with the given name already exists";
        public const string SortArgumentsError = "Order and Attribute must be provided or be null";
        public const string ZeroPage = "PageNumber cannot be zero. The page count starts with 1";
    }
}