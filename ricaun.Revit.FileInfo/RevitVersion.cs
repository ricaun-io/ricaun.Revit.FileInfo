namespace ricaun.Revit.FileInfo
{
    /// <summary>
    /// RevitVersion
    /// </summary>
    public struct RevitVersion
    {
        /// <summary>
        /// Unknown
        /// </summary>
        public static RevitVersion Unknown { get; } = 0;
        private readonly int version;
        private RevitVersion(int version)
        {
            this.version = version;
        }
        /// <summary>
        /// ForgeParameterType
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator RevitVersion(int value)
        {
            return new RevitVersion(value);
        }
        /// <summary>
        /// ForgeParameterType
        /// </summary>
        /// <param name="type"></param>
        public static implicit operator int(RevitVersion type)
        {
            return type.version;
        }
        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(int left, RevitVersion right)
        {
            return right.Equals((RevitVersion)left);
        }
        /// <summary>
        /// Not Equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(int left, RevitVersion right)
        {
            return !right.Equals((RevitVersion)left);
        }
        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(RevitVersion left, int right)
        {
            return left.Equals((RevitVersion)right);
        }
        /// <summary>
        /// Not Equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(RevitVersion left, int right)
        {
            return !left.Equals((RevitVersion)right);
        }
        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(RevitVersion left, RevitVersion right)
        {
            return left.Equals(right);
        }
        /// <summary>
        /// Not Equal
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(RevitVersion left, RevitVersion right)
        {
            return !left.Equals(right);
        }
        /// <summary>
        /// Equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is RevitVersion revitVersion)
            {
                return this.version == revitVersion.version;
            }
            if (obj is int version)
            {
                return this.version == version;
            }
            return base.Equals(obj);
        }
        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.version.GetHashCode();
        }

        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.version.ToString();
        }
    }
}