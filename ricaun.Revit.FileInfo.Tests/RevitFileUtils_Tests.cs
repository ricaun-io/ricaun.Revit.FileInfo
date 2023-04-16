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
        [TestCase("Format: 2020", 2020)]
        [TestCase("Format: 2021", 2021)]
        public void TestFile_TryMatch_Format(string input, int version)
        {
            var isMatch = RevitFileUtils.TryMatchFormat(input, out int revitVersion);
            Assert.IsTrue(isMatch);
            Assert.AreEqual(version, revitVersion);
        }
        [TestCase("Revit Build: Autodesk Revit 2016", 2016)]
        [TestCase("Revit Build: Autodesk Revit 2017 (Build: 20270223_1515(x64))", 2017)]
        public void TestFile_TryMatch_RevitBuild(string input, int version)
        {
            var isMatch = RevitFileUtils.TryMatchRevitBuild(input, out int revitVersion);
            Assert.IsTrue(isMatch);
            Assert.AreEqual(version, revitVersion);
        }
    }
}