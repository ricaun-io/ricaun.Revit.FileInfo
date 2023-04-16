using ricaun.Revit.FileInfo.Utils;

namespace ricaun.Revit.FileInfo
{
    /// <summary>
    /// RevitVersionInfo
    /// </summary>
    public class RevitVersionInfo
    {
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; }
        /// <summary>
        /// RevitVersion
        /// </summary>
        public RevitVersion Version { get; }
        /// <summary>
        /// IsValid
        /// </summary>
        public bool IsValid { get; }
        /// <summary>
        /// RevitVersionInfo
        /// </summary>
        /// <param name="filePath"></param>
        public RevitVersionInfo(string filePath)
        {
            FilePath = filePath;
            Version = RevitFileUtils.GetRevitVersion(filePath);
            IsValid = RevitFileUtils.IsValidRevitFile(filePath);
        }
    }
}