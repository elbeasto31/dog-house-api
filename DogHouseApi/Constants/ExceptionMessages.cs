namespace DogHouseApi.Constants
{
    public static class ExceptionMessages
    {
        public const string AttributeDoesNotExist = "Wrong sort attribute:";
        public const string DogAlreadyExists = "The dog with the given name already exists";
        public const string SortArgumentsError = "Order and Attribute must be provided or be null";
        public const string PageNumberRange = "PageNumber cannot be zero. The page count starts with 1";
        public const string DogWeightRange = "Weight should be a positive number";
        public const string SortOrderValidation = "Invalid order value. Valid values are 'desc' and 'asc'.";
    }
}