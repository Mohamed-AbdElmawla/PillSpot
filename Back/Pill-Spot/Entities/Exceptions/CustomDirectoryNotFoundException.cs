namespace Entities.Exceptions
{
    public sealed class CustomDirectoryNotFoundException : NotFoundException
    {
        public CustomDirectoryNotFoundException(string directoryPath)
          : base($"The directory '{directoryPath}' was not found.") { }
    }
}