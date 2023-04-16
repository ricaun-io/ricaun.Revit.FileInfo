using System;
using System.IO;
using System.IO.Packaging;
using System.Reflection;

namespace ricaun.Revit.FileInfo.StructuredStorage
{
    /// <summary>
    /// StructuredStorageRoot
    /// </summary>
    public class StructuredStorageRoot : IDisposable
    {
        StorageInfo _storageRoot;

        /// <summary>
        /// StructuredStorageRoot
        /// </summary>
        /// <param name="stream"></param>
        /// <exception cref="StructuredStorageException"></exception>
        public StructuredStorageRoot(Stream stream)
        {
            try
            {
                _storageRoot = (StorageInfo)InvokeStorageRootMethod(null, "CreateOnStream", stream);
            }
            catch (Exception ex)
            {
                throw new StructuredStorageException("Cannot get StructuredStorageRoot", ex);
            }
        }

        /// <summary>
        /// StructuredStorageRoot
        /// </summary>
        /// <param name="fileName"></param>
        /// <exception cref="StructuredStorageException"></exception>
        public StructuredStorageRoot(string fileName)
        {
            try
            {
                _storageRoot = (StorageInfo)InvokeStorageRootMethod(null, "Open", fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception ex)
            {
                throw new StructuredStorageException("Cannot get StructuredStorageRoot", ex);
            }
        }

        private static object InvokeStorageRootMethod(
          StorageInfo storageRoot,
          string methodName,
          params object[] methodArgs)
        {
            Type storageRootType = typeof(StorageInfo).Assembly.GetType(
                "System.IO.Packaging.StorageRoot",
                true, false);

            object result = storageRootType.InvokeMember(methodName,
                BindingFlags.Static | BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.InvokeMethod,
                null, storageRoot, methodArgs);

            return result;
        }

        private void CloseStorageRoot()
        {
            InvokeStorageRootMethod(_storageRoot, "Close");
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            CloseStorageRoot();
        }

        #endregion

        /// <summary>
        /// BaseRoot
        /// </summary>
        public StorageInfo BaseRoot
        {
            get { return _storageRoot; }
        }
    }
}