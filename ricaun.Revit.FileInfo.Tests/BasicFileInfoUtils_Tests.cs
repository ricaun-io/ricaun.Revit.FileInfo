using NUnit.Framework;
using ricaun.Revit.FileInfo.StructuredStorage;
using System;
using System.IO;

namespace ricaun.Revit.FileInfo.Tests
{
    public class BasicFileInfoUtils_Tests
    {
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
        public void TestFile_Version(string filePath, int version)
        {
            filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, filePath);
            if (BasicFileInfoUtils.TryBasicFileInfo(filePath, out string[] infos))
            {
                foreach (var info in infos)
                {
                    Console.WriteLine(info);
                }
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}