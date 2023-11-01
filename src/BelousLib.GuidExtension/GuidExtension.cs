namespace BelousLib.GuidExtension;

/// <summary>
///     Guid Extension
/// </summary>
public static class GuidExtension
{
    private const int GuidLength = 32;

    private const char Zero = '0';

    private const char Dash = '-';

    /// <summary>
    ///     Convert GUID to Int16
    /// </summary>
    /// <param name="guid">GUID</param>
    public static short ToInt16(this Guid guid)
    {
        return BitConverter.ToInt16(GetByteArrayFromHexString(guid));
    }

    /// <summary>
    ///     Convert GUID to Int32
    /// </summary>
    /// <param name="guid">GUID</param>
    public static int ToInt32(this Guid guid)
    {
        return BitConverter.ToInt32(GetByteArrayFromHexString(guid));
    }

    /// <summary>
    ///     Convert GUID to Int64
    /// </summary>
    /// <param name="guid">GUID</param>
    public static long ToInt64(this Guid guid)
    {
        return BitConverter.ToInt64(GetByteArrayFromHexString(guid));
    }

    /// <summary>
    ///     Convert GUID to UInt16
    /// </summary>
    /// <param name="guid">GUID</param>
    public static ushort ToUInt16(this Guid guid)
    {
        return BitConverter.ToUInt16(GetByteArrayFromHexString(guid));
    }

    /// <summary>
    ///     Convert GUID to UInt32
    /// </summary>
    /// <param name="guid">GUID</param>
    public static uint ToUInt32(this Guid guid)
    {
        return BitConverter.ToUInt32(GetByteArrayFromHexString(guid));
    }

    /// <summary>
    ///     Convert GUID to UInt64
    /// </summary>
    /// <param name="guid">GUID</param>
    public static ulong ToUInt64(this Guid guid)
    {
        return BitConverter.ToUInt64(GetByteArrayFromHexString(guid));
    }

    /// <summary>
    ///     Convert Int16 to GUID
    /// </summary>
    /// <param name="int16">Int16</param>
    public static Guid ToGuid(this short int16)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(int16)));
    }

    /// <summary>
    ///     Convert Int32 to GUID
    /// </summary>
    /// <param name="int32">Int32</param>
    public static Guid ToGuid(this int int32)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(int32)));
    }

    /// <summary>
    ///     Convert Int64 to GUID
    /// </summary>
    /// <param name="int64">Int64</param>
    public static Guid ToGuid(this long int64)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(int64)));
    }

    /// <summary>
    ///     Convert UInt16 to GUID
    /// </summary>
    /// <param name="uInt16">UInt16</param>
    public static Guid ToGuid(this ushort uInt16)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(uInt16)));
    }

    /// <summary>
    ///     Convert UInt32 to GUID
    /// </summary>
    /// <param name="uInt32">UInt32</param>
    public static Guid ToGuid(this uint uInt32)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(uInt32)));
    }

    /// <summary>
    ///     Convert UInt64 to GUID
    /// </summary>
    /// <param name="uInt64">UInt64</param>
    public static Guid ToGuid(this ulong uInt64)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(uInt64)));
    }

    /// <summary>
    ///     Create a new guid
    /// </summary>
    /// <param name="value">Numeric value in HEX</param>
    /// <returns>
    ///     New GUID
    /// </returns>
    private static Guid CreateGuid(string value)
    {
        var hexArray = value.ToCharArray();

        var charArray = new char[GuidLength];

        Array.Copy(hexArray, 0, charArray, 0, hexArray.Length);

        for (var index = hexArray.Length; index < GuidLength; index++) charArray[index] = Zero;

        return new Guid(new string(charArray));
    }

    /// <summary>
    ///     Get Byte Array From Hex String
    /// </summary>
    /// <param name="guid">GUID</param>
    /// <returns>
    ///     Byte array
    /// </returns>
    private static byte[] GetByteArrayFromHexString(Guid guid)
    {
        return Convert.FromHexString(guid.ToString()
            .Replace(Dash.ToString(), string.Empty));
    }
}