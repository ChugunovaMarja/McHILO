[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
sealed class MessageAttribute : Attribute
{
    public string Message { get; }

    public MessageAttribute(string message)
    {
        Message = message;
    }
}