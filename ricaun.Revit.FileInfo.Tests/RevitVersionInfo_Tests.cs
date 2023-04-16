using NUnit.Framework;
using ricaun.Revit.FileInfo.Utils;
using System;
using System.IO;

namespace ricaun.Revit.FileInfo.Tests
{
    public class RevitVersionInfo_Tests
    {
        [TestCase("Files/2017/FamilyTemplate.rft", 2017)]
        [TestCase("Files/2021/FamilyTemplate.rft", 2021)]
        [TestCase("Files/2022/FamilyTemplate.rft", 2022)]
        [TestCase("Files/2023/FamilyTemplate.rft", 2023)]

        [TestCase("Files/2014/Family.rfa", 2014)]
        [TestCase("Files/2015/Family.rfa", 2015)]
        [TestCase("Files/2016/Family.rfa", 2016)]
        [TestCase("Files/2017/Family.rfa", 2017)]
        [TestCase("Files/2018/Family.rfa", 2018)]
        [TestCase("Files/2019/Family.rfa", 2019)]
        [TestCase("Files/2020/Family.rfa", 2020)]
        [TestCase("Files/2021/Family.rfa", 2021)]
        [TestCase("Files/2022/Family.rfa", 2022)]
        [TestCase("Files/2023/Family.rfa", 2023)]
        [TestCase("Files/2024/Family.rfa", 2024)]

        [TestCase("Files/2024/FamilyTemplate.rft", 2024)]
        [TestCase("Files/2024/Project.rvt", 2024)]
        [TestCase("Files/2024/ProjectTemplate.rte", 2024)]
        public void TestFile_Version(string filePath, int version)
        {
            filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, filePath);
            RevitVersionInfo revitVersionInfo = new RevitVersionInfo(filePath);
            Assert.IsTrue(revitVersionInfo.IsValid);
            Console.WriteLine(revitVersionInfo.Version);
            Assert.IsTrue(version.Equals(revitVersionInfo.Version));
        }
        [TestCase(RevitExtension.Project)]
        [TestCase(RevitExtension.ProjectTemplate)]
        [TestCase(RevitExtension.Family)]
        [TestCase(RevitExtension.FamilyTemplate)]
        public void TestFile_Extension(string extension)
        {
            RevitVersionInfo revitVersionInfo = CreateTempFile(extension);
            Assert.IsTrue(revitVersionInfo.IsValid);
        }

        [TestCase(".txt")]
        [TestCase(".dwg")]
        public void TestFile_NotExtension(string extension)
        {
            RevitVersionInfo revitVersionInfo = CreateTempFile(extension);
            Assert.IsFalse(revitVersionInfo.IsValid);
        }

        private RevitVersionInfo CreateTempFile(string extension)
        {
            var filePath = Path.GetTempFileName() + extension;
            File.WriteAllText(filePath, string.Empty);
            RevitVersionInfo revitVersionInfo = new RevitVersionInfo(filePath);
            File.Delete(filePath);
            return revitVersionInfo;
        }
    }
}