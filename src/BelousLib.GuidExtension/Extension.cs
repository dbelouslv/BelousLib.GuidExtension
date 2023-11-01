namespace BelousLib.GuidExtension;

/// <summary>
///     Guid Extension
/// </summary>
public static class Extension
{
    private const int GuidLength = 32;

    private const char Zero = '0';

    private const char Dash = '-';

    /// <summary>
    ///     Convert GUID to Int16
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static short ToInt16(this Guid entityGuid)
    {
        return BitConverter.ToInt16(GetByteArrayFromHexString(entityGuid));
    }

    /// <summary>
    ///     Convert GUID to Int32
    /// </summary>
    /// <param name="guid">GUID</param>
    public static int ToInt32(this Guid entityGuid)
    {
        return BitConverter.ToInt32(GetByteArrayFromHexString(entityGuid));
    }

    /// <summary>
    ///     Convert GUID to Int64
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static long ToInt64(this Guid entityGuid)
    {
        return BitConverter.ToInt64(GetByteArrayFromHexString(entityGuid));
    }

    /// <summary>
    ///     Convert GUID to UInt16
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static ushort ToUInt16(this Guid entityGuid)
    {
        return BitConverter.ToUInt16(GetByteArrayFromHexString(entityGuid));
    }

    /// <summary>
    ///     Convert GUID to UInt32
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static uint ToUInt32(this Guid entityGuid)
    {
        return BitConverter.ToUInt32(GetByteArrayFromHexString(entityGuid));
    }

    /// <summary>
    ///     Convert GUID to UInt64
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static ulong ToUInt64(this Guid entityGuid)
    {
        return BitConverter.ToUInt64(GetByteArrayFromHexString(entityGuid));
    }

    /// <summary>
    ///     Convert GUID to String without dashes
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static string ToStringWithoutDashes(this Guid entityGuid)
    {
        return entityGuid.ToString().Replace(Dash.ToString(), string.Empty, StringComparison.CurrentCulture);
    }

    /// <summary>
    ///     Convert Int16 to GUID
    /// </summary>
    /// <param name="value">Int16</param>
    public static Guid ToGuid(this short value)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(value)));
    }

    /// <summary>
    ///     Convert Int32 to GUID
    /// </summary>
    /// <param name="value">Int32</param>
    public static Guid ToGuid(this int value)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(value)));
    }

    /// <summary>
    ///     Convert Int64 to GUID
    /// </summary>
    /// <param name="value">Int64</param>
    public static Guid ToGuid(this long value)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(value)));
    }

    /// <summary>
    ///     Convert UInt16 to GUID
    /// </summary>
    /// <param name="value">UInt16</param>
    public static Guid ToGuid(this ushort value)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(value)));
    }

    /// <summary>
    ///     Convert UInt32 to GUID
    /// </summary>
    /// <param name="value">UInt32</param>
    public static Guid ToGuid(this uint value)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(value)));
    }

    /// <summary>
    ///     Convert UInt64 to GUID
    /// </summary>
    /// <param name="value">UInt64</param>
    public static Guid ToGuid(this ulong value)
    {
        return CreateGuid(Convert.ToHexString(BitConverter.GetBytes(value)));
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
        return Convert.FromHexString(guid.ToString().Replace(Dash.ToString(), string.Empty, StringComparison.CurrentCulture));
    }
}