using NUnit.Framework;
using ricaun.Revit.FileInfo.Utils;

namespace ricaun.Revit.FileInfo.Tests
{
    public class RevitFileUtils_Tests
    {
        [TestCase("NotExist.rvt")]
        public void TestFile_NotExists_Version(string filePath)
        {
            var version = RevitFileUtils.GetRevitVersion(filePath);
            Assert.AreEqual(RevitVersion.Unknown, version);
        }
        [TestCase("NotExist.rvt")]
        public void TestFile_NotExists_IsValid(string filePath)
        {
            var isValid = RevitFileUtils.IsValidRevitFileExtension(filePath);
            Assert.IsTrue(isValid);
        }
    }
}