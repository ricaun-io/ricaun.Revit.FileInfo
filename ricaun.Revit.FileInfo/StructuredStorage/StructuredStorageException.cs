using System;

namespace ricaun.Revit.FileInfo.StructuredStorage
{
    /// <summary>
    /// StructuredStorageException
    /// </summary>
    public class StructuredStorageException : Exception
    {
        /// <summary>
        /// StructuredStorageException
        /// </summary>
        public StructuredStorageException()
        {
        }

        /// <summary>
        /// StructuredStorageException
        /// </summary>
        /// <param name="message"></param>
        public StructuredStorageException(string message) : base(message)
        {
        }

        /// <summary>
        /// StructuredStorageException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public StructuredStorageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}