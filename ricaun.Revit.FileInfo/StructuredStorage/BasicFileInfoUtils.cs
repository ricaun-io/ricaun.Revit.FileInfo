using System;
using System.IO;
using System.IO.Packaging;
using System.Text;

namespace ricaun.Revit.FileInfo.StructuredStorage
{
    /// <summary>
    /// BasicFileInfoUtils
    /// </summary>
    public static class BasicFileInfoUtils
    {
        /// <summary>
        /// TryBasicFileInfo
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileInfoDatas"></param>
        /// <returns></returns>
        public static bool TryBasicFileInfo(string filePath, out string[] fileInfoDatas)
        {
            fileInfoDatas = null;

            if (!TryGetRawBasicFileInfo(filePath, out byte[] rawData))
            {
                return false;
            }

            var fileInfoData = Encoding.UTF8.GetString(rawData).Replace("\0", string.Empty);

            fileInfoDatas = fileInfoData.Split(new string[] { "\0", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            return true;
        }

        private static bool TryGetRawBasicFileInfo(string filePath, out byte[] rawData)
        {
            rawData = null;

            if (!StructuredStorageUtils.IsFileStucturedStorage(filePath, false))
            {
                return false;
            }

            rawData = GetRawBasicFileInfo(filePath);

            return true;
        }
        private const string StreamName = "BasicFileInfo";
        private static byte[] GetRawBasicFileInfo(string revitFileName)
        {
            if (!StructuredStorageUtils.IsFileStucturedStorage(revitFileName))
            {
                throw new NotSupportedException("File is not a structured storage file");
            }

            using (StructuredStorageRoot ssRoot =
                new StructuredStorageRoot(revitFileName))
            {
                if (!ssRoot.BaseRoot.StreamExists(StreamName))
                    throw new NotSupportedException(string.Format("File doesn't contain {0} stream", StreamName));

                StreamInfo imageStreamInfo = ssRoot.BaseRoot.GetStreamInfo(StreamName);

                using (Stream stream = imageStreamInfo.GetStream(FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    return buffer;
                }
            }
        }
    }
}
