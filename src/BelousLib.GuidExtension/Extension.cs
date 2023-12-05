using System.Security.Cryptography;

namespace BelousLib.GuidExtension;

/// <summary>
///     Guid Extension
/// </summary>
public static class Extension
{
    private const int LastGuidDigitIndex = 15;

    private const string Dash = "-";

    private const string Hex = "0123456789ABCDEF";

    /// <summary>
    ///     Convert GUID to Int16
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static short ToInt16(this Guid entityGuid)
    {
        return BitConverter.ToInt16(entityGuid.ToByteArray());
    }

    /// <summary>
    ///     Convert IEnumerable GUID to IEnumerable Int16
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<short> ToInt16(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToInt16);
    }

    /// <summary>
    ///     Convert GUID? to Int16?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static short? ToInt16(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? BitConverter.ToInt16(entityGuid.Value.ToByteArray()) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable Int16?
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<short?> ToInt16(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToInt16);
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
    ///     Convert IEnumerable GUID to IEnumerable Int32
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<int> ToInt32(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToInt32);
    }

    /// <summary>
    ///     Convert GUID? to Int32?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static int? ToInt32(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? BitConverter.ToInt32(entityGuid.Value.ToByteArray()) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable Int32?
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<int?> ToInt32(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToInt32);
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
    ///     Convert IEnumerable GUID to IEnumerable Int64
    /// </summary>
    /// <param name="guids">GUID</param>
    public static IEnumerable<long> ToInt64(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToInt64);
    }

    /// <summary>
    ///     Convert GUID? to Int64?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static long? ToInt64(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? BitConverter.ToInt64(entityGuid.Value.ToByteArray()) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable Int64?
    /// </summary>
    /// <param name="guids">GUID</param>
    public static IEnumerable<long?> ToInt64(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToInt64);
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
    ///     Convert IEnumerable GUID to IEnumerable UInt16
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<ushort> ToUInt16(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToUInt16);
    }

    /// <summary>
    ///     Convert GUID? to UInt16?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static ushort? ToUInt16(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? BitConverter.ToUInt16(entityGuid.Value.ToByteArray()) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable UInt16?
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<ushort?> ToUInt16(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToUInt16);
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
    ///     Convert IEnumerable GUID to IEnumerable UInt32
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<uint> ToUInt32(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToUInt32);
    }

    /// <summary>
    ///     Convert GUID? to UInt32?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static uint? ToUInt32(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? BitConverter.ToUInt32(entityGuid.Value.ToByteArray()) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable UInt32?
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<uint?> ToUInt32(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToUInt32);
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
    ///     Convert IEnumerable GUID to IEnumerable UInt64
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<ulong> ToUInt64(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToUInt64);
    }

    /// <summary>
    ///     Convert GUID? to UInt64?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static ulong? ToUInt64(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? BitConverter.ToUInt64(entityGuid.Value.ToByteArray()) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable UInt64?
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<ulong?> ToUInt64(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToUInt64);
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
    ///     Convert IEnumerable GUID to IEnumerable Float
    /// </summary>
    /// <param name="guids">GUID</param>
    public static IEnumerable<float> ToSingle(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToSingle);
    }

    /// <summary>
    ///     Convert GUID? to Float?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static float? ToSingle(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? BitConverter.ToSingle(entityGuid.Value.ToByteArray()) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable Float?
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<float?> ToSingle(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToSingle);
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
    ///     Convert IEnumerable GUID to IEnumerable Double
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<double> ToDouble(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToDouble);
    }

    /// <summary>
    ///     Convert GUID? to Double?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static double? ToDouble(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? BitConverter.ToDouble(entityGuid.Value.ToByteArray()) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable Double?
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<double?> ToDouble(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToDouble);
    }

    /// <summary>
    ///     Convert GUID to String
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static string ToStringFromGuid(this Guid entityGuid)
    {
        return entityGuid.ToString();
    }

    /// <summary>
    ///     Convert IEnumerable GUID to IEnumerable String
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<string> ToStringFromGuid(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToStringFromGuid);
    }

    /// <summary>
    ///     Convert GUID? to String?
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static string? ToStringFromGuid(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? entityGuid.Value.ToString() : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable String?
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<string?> ToStringFromGuid(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToStringFromGuid);
    }

    /// <summary>
    ///     Convert GUID to String without dashes
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static string ToStringFromGuidWithoutDashes(this Guid entityGuid)
    {
        return entityGuid.ToString().Replace(Dash, string.Empty, StringComparison.CurrentCulture);
    }

    /// <summary>
    ///     Convert IEnumerable GUID to IEnumerable String without dashes
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<string> ToStringFromGuidWithoutDashes(this IEnumerable<Guid> guids)
    {
        return guids.Select(ToStringFromGuidWithoutDashes);
    }

    /// <summary>
    ///     Convert GUID? to String? without dashes
    /// </summary>
    /// <param name="entityGuid">GUID</param>
    public static string? ToStringFromGuidWithoutDashes(this Guid? entityGuid)
    {
        return entityGuid.HasValue ? entityGuid.Value.ToString().Replace(Dash, string.Empty, StringComparison.CurrentCulture) : null;
    }

    /// <summary>
    ///     Convert IEnumerable GUID? to IEnumerable String? without dashes
    /// </summary>
    /// <param name="guids">GUIDs</param>
    public static IEnumerable<string?> ToStringFromGuidWithoutDashes(this IEnumerable<Guid?> guids)
    {
        return guids.Select(ToStringFromGuidWithoutDashes);
    }

    /// <summary>
    ///     Convert Int16 to GUID
    /// </summary>
    /// <param name="value">Int16</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid ToGuid(this short value, bool enableZeroRemoving = false)
    {
        return ToCreateGuid(BitConverter.GetBytes(value), enableZeroRemoving);
    }

    /// <summary>
    ///     Convert IEnumerable Int16 to IEnumerable GUID
    /// </summary>
    /// <param name="values">Int16</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid> ToGuid(this IEnumerable<short> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Int16? to GUID?
    /// </summary>
    /// <param name="num">Int16</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid? ToGuid(this short? num, bool enableZeroRemoving = false)
    {
        return num.HasValue ? ToCreateGuid(BitConverter.GetBytes(num.Value), enableZeroRemoving) : null;
    }

    /// <summary>
    ///     Convert IEnumerable Int16? to IEnumerable GUID?
    /// </summary>
    /// <param name="values">Int16</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid?> ToGuid(this IEnumerable<short?> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Int32 to GUID
    /// </summary>
    /// <param name="value">Int32</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid ToGuid(this int value, bool enableZeroRemoving = false)
    {
        return ToCreateGuid(BitConverter.GetBytes(value), enableZeroRemoving);
    }

    /// <summary>
    ///     Convert IEnumerable Int32 to IEnumerable GUID
    /// </summary>
    /// <param name="values">Int32</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid> ToGuid(this IEnumerable<int> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Int32? to GUID?
    /// </summary>
    /// <param name="num">Int32</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid? ToGuid(this int? num, bool enableZeroRemoving = false)
    {
        return num.HasValue ? ToCreateGuid(BitConverter.GetBytes(num.Value), enableZeroRemoving) : null;
    }

    /// <summary>
    ///     Convert IEnumerable Int32? to IEnumerable GUID?
    /// </summary>
    /// <param name="values">Int32</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid?> ToGuid(this IEnumerable<int?> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Int64 to GUID
    /// </summary>
    /// <param name="value">Int64</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid ToGuid(this long value, bool enableZeroRemoving = false)
    {
        return ToCreateGuid(BitConverter.GetBytes(value), enableZeroRemoving);
    }

    /// <summary>
    ///     Convert IEnumerable Int64 to IEnumerable GUID
    /// </summary>
    /// <param name="values">Int64</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid> ToGuid(this IEnumerable<long> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Int64? to GUID?
    /// </summary>
    /// <param name="num">Int64</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid? ToGuid(this long? num, bool enableZeroRemoving = false)
    {
        return num.HasValue ? ToCreateGuid(BitConverter.GetBytes(num.Value), enableZeroRemoving) : null;
    }

    /// <summary>
    ///     Convert IEnumerable Int64? to IEnumerable GUID?
    /// </summary>
    /// <param name="values">Int64</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid?> ToGuid(this IEnumerable<long?> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert UInt16 to GUID
    /// </summary>
    /// <param name="value">UInt16</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid ToGuid(this ushort value, bool enableZeroRemoving = false)
    {
        return ToCreateGuid(BitConverter.GetBytes(value), enableZeroRemoving);
    }

    /// <summary>
    ///     Convert IEnumerable UInt16 to IEnumerable GUID
    /// </summary>
    /// <param name="values">UInt16</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid> ToGuid(this IEnumerable<ushort> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert UInt16? to GUID?
    /// </summary>
    /// <param name="num">UInt16</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid? ToGuid(this ushort? num, bool enableZeroRemoving = false)
    {
        return num.HasValue ? ToCreateGuid(BitConverter.GetBytes(num.Value), enableZeroRemoving) : null;
    }

    /// <summary>
    ///     Convert IEnumerable UInt16? to IEnumerable GUID?
    /// </summary>
    /// <param name="values">UInt16</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid?> ToGuid(this IEnumerable<ushort?> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert UInt32 to GUID
    /// </summary>
    /// <param name="value">UInt32</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid ToGuid(this uint value, bool enableZeroRemoving = false)
    {
        return ToCreateGuid(BitConverter.GetBytes(value), enableZeroRemoving);
    }

    /// <summary>
    ///     Convert IEnumerable UInt32 to IEnumerable GUID
    /// </summary>
    /// <param name="values">UInt32</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid> ToGuid(this IEnumerable<uint> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert UInt32? to GUID?
    /// </summary>
    /// <param name="num">UInt32</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid? ToGuid(this uint? num, bool enableZeroRemoving = false)
    {
        return num.HasValue ? ToCreateGuid(BitConverter.GetBytes(num.Value), enableZeroRemoving) : null;
    }

    /// <summary>
    ///     Convert IEnumerable UInt32? to IEnumerable GUID?
    /// </summary>
    /// <param name="values">UInt32</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid?> ToGuid(this IEnumerable<uint?> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert UInt64 to GUID
    /// </summary>
    /// <param name="value">UInt64</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid ToGuid(this ulong value, bool enableZeroRemoving = false)
    {
        return ToCreateGuid(BitConverter.GetBytes(value), enableZeroRemoving);
    }

    /// <summary>
    ///     Convert IEnumerable UInt64 to IEnumerable GUID
    /// </summary>
    /// <param name="values">UInt64</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid> ToGuid(this IEnumerable<ulong> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert UInt64? to GUID?
    /// </summary>
    /// <param name="num">UInt64</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid? ToGuid(this ulong? num, bool enableZeroRemoving = false)
    {
        return num.HasValue ? ToCreateGuid(BitConverter.GetBytes(num.Value), enableZeroRemoving) : null;
    }

    /// <summary>
    ///     Convert IEnumerable UInt64? to IEnumerable GUID?
    /// </summary>
    /// <param name="values">UInt64</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid?> ToGuid(this IEnumerable<ulong?> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Float to GUID
    /// </summary>
    /// <param name="value">Float</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid ToGuid(this float value, bool enableZeroRemoving = false)
    {
        return ToCreateGuid(BitConverter.GetBytes(value), enableZeroRemoving);
    }

    /// <summary>
    ///     Convert IEnumerable Float to IEnumerable GUID
    /// </summary>
    /// <param name="values">Float</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid> ToGuid(this IEnumerable<float> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Float? to GUID?
    /// </summary>
    /// <param name="num">Float</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid? ToGuid(this float? num, bool enableZeroRemoving = false)
    {
        return num.HasValue ? ToCreateGuid(BitConverter.GetBytes(num.Value), enableZeroRemoving) : null;
    }

    /// <summary>
    ///     Convert IEnumerable Float? to IEnumerable GUID?
    /// </summary>
    /// <param name="values">Float</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid?> ToGuid(this IEnumerable<float?> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Double to GUID
    /// </summary>
    /// <param name="value">Double</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid ToGuid(this double value, bool enableZeroRemoving = false)
    {
        return ToCreateGuid(BitConverter.GetBytes(value), enableZeroRemoving);
    }

    /// <summary>
    ///     Convert IEnumerable Double to IEnumerable GUID
    /// </summary>
    /// <param name="values">Double</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid> ToGuid(this IEnumerable<double> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert Double? to GUID?
    /// </summary>
    /// <param name="num">Double</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static Guid? ToGuid(this double? num, bool enableZeroRemoving = false)
    {
        return num.HasValue ? ToCreateGuid(BitConverter.GetBytes(num.Value), enableZeroRemoving) : null;
    }

    /// <summary>
    ///     Convert IEnumerable Double? to IEnumerable GUID?
    /// </summary>
    /// <param name="values">Double</param>
    /// <param name="enableZeroRemoving">Enable Zero Removing</param>
    public static IEnumerable<Guid?> ToGuid(this IEnumerable<double?> values, bool enableZeroRemoving = false)
    {
        return values.Select(value => value.ToGuid(enableZeroRemoving));
    }

    /// <summary>
    ///     Convert String to GUID
    /// </summary>
    /// <param name="value">String</param>
    public static Guid ToGuidFromString(this string value)
    {
        return ToCreateGuid(new Guid(value).ToByteArray());
    }

    /// <summary>
    ///     Convert IEnumerable String to IEnumerable GUID
    /// </summary>
    /// <param name="values">String</param>
    public static IEnumerable<Guid> ToGuidFromString(this IEnumerable<string> values)
    {
        return values.Select(value => value.ToGuidFromString());
    }

    /// <summary>
    ///     Create a GUID
    /// </summary>
    /// <param name="byteArray">Byte array</param>
    /// <param name="enableZeroRemoving">Flag to enable zero removing</param>
    private static Guid ToCreateGuid(byte[] byteArray, bool enableZeroRemoving = false)
    {
        // Initialize the remaining bytes of the Guid with zeros
        var guidBytes = new byte[16];

        Array.Copy(byteArray, guidBytes, byteArray.Length);

        return !enableZeroRemoving ? new Guid(guidBytes) : ToFillGuid(new Guid(guidBytes));
    }

    /// <summary>
    ///     Fill guid
    /// </summary>
    /// <param name="newGuid">GUID</param>
    private static Guid ToFillGuid(Guid newGuid)
    {
        var charArray = newGuid.ToStringFromGuidWithoutDashes().ToCharArray();
        var generatedHex = GenerateRandomString(charArray.Length - LastGuidDigitIndex + 1);

        for (var index = LastGuidDigitIndex + 1; index < charArray.Length; index++)
        {
            charArray[index] = generatedHex[charArray.Length - index];
        }

        return new Guid(new string(charArray));
    }

    /// <summary>
    ///     Return a random value from HEX
    /// </summary>
    /// <param name="length">Length</param>
    private static string GenerateRandomString(int length)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Invalid arguments for generating a random string.");
        }

        byte[] randomBytes = new byte[length];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
        }

        char[] randomChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            int randomIndex = randomBytes[i] % Hex.Length;
            randomChars[i] = Hex[randomIndex];
        }

        return new string(randomChars);
    }
}