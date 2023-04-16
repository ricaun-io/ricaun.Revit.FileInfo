using System.IO;
using System.Runtime.InteropServices;

namespace ricaun.Revit.FileInfo.StructuredStorage
{
    public static class StructuredStorageUtils
    {
        [DllImport("ole32.dll")]
        static extern int StgIsStorageFile([MarshalAs(UnmanagedType.LPWStr)] string pwcsName);

        public static bool IsFileStucturedStorage(string fileName)
        {
            int res = StgIsStorageFile(fileName);

            if (res == 0)
                return true;

            if (res == 1)
                return false;

            throw new FileNotFoundException("File not found", fileName);
        }
    }
}