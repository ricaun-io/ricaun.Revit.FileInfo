using ricaun.Revit.FileInfo.StructuredStorage;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ricaun.Revit.FileInfo.Utils
{
    /// <summary>
    /// RevitFileUtils
    /// </summary>
    public class RevitFileUtils
    {
        /// <summary>
        /// GetRevitVersion
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static RevitVersion GetRevitVersion(string filePath)
        {
            if (BasicFileInfoUtils.TryBasicFileInfo(filePath, out string[] infos))
            {
                foreach (var info in infos)
                {
                    if (TryMatchRevitBuild(info, out int buildVersion))
                    {
                        return buildVersion;
                    }

                    if (TryMatchFormat(info, out int formatVersion))
                    {
                        return formatVersion;
                    }
                }
            }
            return RevitVersion.Unknown;
        }

        /// <summary>
        /// Regex to get the version: "Revit Build: Autodesk Revit 2017 (Build: 20270223_1515(x64))"
        /// </summary>
        /// <returns></returns>
        internal static bool TryMatchRevitBuild(string input, out int revitVersion)
        {
            revitVersion = 0;
            var regex = new Regex(@"^Revit Build:.*?(\d{4})", RegexOptions.IgnoreCase);
            var match = regex.Match(input);
            if (match.Success)
            {
                string versionNumber = match.Groups[1].Value;
                if (int.TryParse(versionNumber, out revitVersion))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Regex to get the version: "Format: 2024"
        /// <code>Revit File in Version +2019</code>
        /// </summary>
        /// <param name="input"></param>
        /// <param name="revitVersion"></param>
        /// <returns></returns>
        internal static bool TryMatchFormat(string input, out int revitVersion)
        {
            revitVersion = 0;
            var regex = new Regex(@"^Format:.*?(\d{4})", RegexOptions.IgnoreCase);
            var match = regex.Match(input);
            if (match.Success)
            {
                string versionNumber = match.Groups[1].Value;
                if (int.TryParse(versionNumber, out revitVersion))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// IsValidRevitFile
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsValidRevitFile(string filePath)
        {
            var extension = Path.GetExtension(filePath)?.ToLower();
            switch (extension)
            {
                case RevitExtension.Project:
                case RevitExtension.Family:
                case RevitExtension.ProjectTemplate:
                case RevitExtension.FamilyTemplate:
                    return true;
            }
            return false;
        }
    }
}