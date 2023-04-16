using NUnit.Framework;

namespace ricaun.Revit.FileInfo.Tests
{
    public class RevitVersion_Tests
    {
        [Test]
        public void Test_RevitVersion_Unknown_Equals()
        {
            Assert.IsTrue(RevitVersion.Unknown.Equals(0));
            Assert.IsTrue(0.Equals(RevitVersion.Unknown));
        }
        [Test]
        public void Test_RevitVersion_Unknown_HashCode()
        {
            Assert.IsTrue(RevitVersion.Unknown.GetHashCode() == 0.GetHashCode());
        }
        [Test]
        public void Test_RevitVersion_Unknown_Operator()
        {
            Assert.IsTrue(RevitVersion.Unknown == 0);
            Assert.IsTrue(0 == RevitVersion.Unknown);

            Assert.IsFalse(0 != RevitVersion.Unknown);
            Assert.IsFalse(RevitVersion.Unknown != 0);

            Assert.IsTrue((RevitVersion)1 != RevitVersion.Unknown);
            Assert.IsTrue(RevitVersion.Unknown != (RevitVersion)1);

            Assert.IsFalse((RevitVersion)1 == RevitVersion.Unknown);
            Assert.IsFalse(RevitVersion.Unknown == (RevitVersion)1);
        }
    }
}