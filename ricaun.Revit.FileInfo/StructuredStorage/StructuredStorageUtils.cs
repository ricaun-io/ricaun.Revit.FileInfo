using System.IO;
using System.Runtime.InteropServices;

namespace ricaun.Revit.FileInfo.StructuredStorage
{
    /// <summary>
    /// StructuredStorageUtils
    /// </summary>
    public static class StructuredStorageUtils
    {
        [DllImport("ole32.dll")]
        static extern int StgIsStorageFile([MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

        /// <summary>
        /// IsFileStucturedStorage
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="throwIfNotExist"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static bool IsFileStucturedStorage(string fileName, bool throwIfNotExist = true)
        {
            int res = StgIsStorageFile(fileName);

            if (res == 0)
                return true;

            if (res == 1)
                return false;

            if (throwIfNotExist)
                throw new FileNotFoundException("File not found", fileName);

            return false;
        }
    }
}