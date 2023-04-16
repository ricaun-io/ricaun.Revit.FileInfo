using ricaun.Revit.FileInfo.Utils;

namespace ricaun.Revit.FileInfo
{
    /// <summary>
    /// RevitFileInfo
    /// </summary>
    public class RevitFileInfo
    {
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; }
        /// <summary>
        /// Version
        /// </summary>
        public RevitVersion Version { get; }
        /// <summary>
        /// IsValid
        /// </summary>
        public bool IsValid { get; }
        /// <summary>
        /// RevitFileInfo
        /// </summary>
        /// <param name="filePath"></param>
        public RevitFileInfo(string filePath)
        {
            FilePath = filePath;
            Version = RevitFileUtils.GetRevitVersion(filePath);
            IsValid = RevitFileUtils.IsValidRevitFileExtension(filePath);
        }
    }
}