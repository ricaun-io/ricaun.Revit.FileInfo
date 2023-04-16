using ricaun.Revit.FileInfo.Utils;

namespace ricaun.Revit.FileInfo
{
    /// <summary>
    /// RevitFileInfo
    /// </summary>
    public class RevitFileInfo
    {
        /// <summary>
        /// Get RevitVersion from <paramref name="filePath"/>
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static RevitVersion GetRevitVersion(string filePath) => RevitFileUtils.GetRevitVersion(filePath);
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; }
        /// <summary>
        /// Version
        /// </summary>
        public RevitVersion Version { get; }
        /// <summary>
        /// Is Valid File Extension (.rvt, .rfa, .rte, .rft)
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