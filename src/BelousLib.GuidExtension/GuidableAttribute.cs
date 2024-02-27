namespace BelousLib.GuidExtension
{
    /// <summary>
    ///     Set this attribute only If you want to convert your field 'ToGuid()'.
    ///     For String only supports text up to 16 characters.
    ///     Check documentation before using this attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class GuidableAttribute(bool enableZeroRemoving = true) : Attribute
    {
        public bool EnableZeroRemoving { get; } = enableZeroRemoving;
    }
}
