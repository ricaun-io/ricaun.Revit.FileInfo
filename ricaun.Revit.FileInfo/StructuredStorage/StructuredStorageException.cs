using System;

namespace ricaun.Revit.FileInfo.StructuredStorage
{
    public class StructuredStorageException : Exception
    {
        public StructuredStorageException()
        {
        }

        public StructuredStorageException(string message) : base(message)
        {
        }

        public StructuredStorageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}