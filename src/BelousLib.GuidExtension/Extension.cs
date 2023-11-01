namespace BelousLib.GuidExtension;

/// <summary>
///     Guid Extension
/// </summary>
public static class Extension
{
    /// <summary>
    ///     Convert GUID to Int16
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static short ToInt16(this Guid entityGuid)
    {
        return BitConverter.ToInt16(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert GUID to Int32
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static int ToInt32(this Guid entityGuid)
    {
        return BitConverter.ToInt32(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert GUID to Int64
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static long ToInt64(this Guid entityGuid)
    {
        return BitConverter.ToInt64(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert GUID to UInt16
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static ushort ToUInt16(this Guid entityGuid)
    {
        return BitConverter.ToUInt16(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert GUID to UInt32
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static uint ToUInt32(this Guid entityGuid)
    {
        return BitConverter.ToUInt32(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert GUID to UInt64
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static ulong ToUInt64(this Guid entityGuid)
    {
        return BitConverter.ToUInt64(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert GUID to Float
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static float ToSingle(this Guid entityGuid)
    {
        return BitConverter.ToSingle(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert GUID to Double
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static double ToDouble(this Guid entityGuid)
    {
        return BitConverter.ToDouble(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert GUID to String without dashes
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static string ToStringFromGuid(this Guid entityGuid)
    {
        return entityGuid.ToString();
    }

    /// <summary>
    ///     Convert Int16 to GUID
    /// </summary>
    /// <param name="value">Int16</param>
    public static Guid ToGuid(this short value)
    {
        return CreateGuid(BitConverter.GetBytes(value));
    }

    /// <summary>
    ///     Convert Int32 to GUID
    /// </summary>
    /// <param name="value">Int32</param>
    public static Guid ToGuid(this int value)
    {
        return CreateGuid(BitConverter.GetBytes(value));
    }

    /// <summary>
    ///     Convert Int64 to GUID
    /// </summary>
    /// <param name="value">Int64</param>
    public static Guid ToGuid(this long value)
    {
        return CreateGuid(BitConverter.GetBytes(value));
    }

    /// <summary>
    ///     Convert UInt16 to GUID
    /// </summary>
    /// <param name="value">UInt16</param>
    public static Guid ToGuid(this ushort value)
    {
        return CreateGuid(BitConverter.GetBytes(value));
    }

    /// <summary>
    ///     Convert UInt32 to GUID
    /// </summary>
    /// <param name="value">UInt32</param>
    public static Guid ToGuid(this uint value)
    {
        return CreateGuid(BitConverter.GetBytes(value));
    }

    /// <summary>
    ///     Convert UInt64 to GUID
    /// </summary>
    /// <param name="value">UInt64</param>
    public static Guid ToGuid(this ulong value)
    {
        return CreateGuid(BitConverter.GetBytes(value));
    }

    /// <summary>
    ///     Convert Float to GUID
    /// </summary>
    /// <param name="value">Float</param>
    public static Guid ToGuid(this float value)
    {
        return CreateGuid(BitConverter.GetBytes(value));
    }

    /// <summary>
    ///     Convert Double to GUID
    /// </summary>
    /// <param name="value">Double</param>
    public static Guid ToGuid(this double value)
    {
        return CreateGuid(BitConverter.GetBytes(value));
    }

    /// <summary>
    ///     Convert String to GUID
    /// </summary>
    /// <param name="value">String</param>
    public static Guid ToGuidFromString(this string value)
    {
        return CreateGuid(new Guid(value).ToByteArray());
    }

    private static Guid CreateGuid(byte[] byteArray)
    {
        // Initialize the remaining bytes of the Guid with zeros
        var guidBytes = new byte[16];

        Array.Copy(byteArray, guidBytes, byteArray.Length);

        return new Guid(guidBytes);
    }
}