namespace BelousLib.GuidExtension
{
    /// <summary>
    ///     Set this attribute only If you want to convert your field 'ToGuid()'
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class GuidableAttribute(bool enableZeroRemoving = true) : Attribute
    {
        public bool EnableZeroRemoving { get; } = enableZeroRemoving;
    }
}
