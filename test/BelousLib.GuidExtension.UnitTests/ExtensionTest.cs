namespace BelousLib.GuidExtension.UnitTests;

public class ExtensionTest
{
    [Fact]
    public void EqualUInt16Test()
    {
        for (var i = ushort.MinValue; i < ushort.MaxValue; i++) Assert.Equal(i, i.ToGuid().ToUInt16());
    }

    [Fact]
    public void EqualUInt32Test()
    {
        for (var i = uint.MinValue; i < uint.MaxValue; i++) Assert.Equal(i, i.ToGuid().ToUInt32());
    }

    [Fact]
    public void EqualUInt64Test()
    {
        Assert.Equal(ulong.MinValue, ulong.MinValue.ToGuid().ToUInt64());
        Assert.Equal(ulong.MaxValue, ulong.MaxValue.ToGuid().ToUInt64());
    }

    [Fact]
    public void EqualInt16Test()
    {
        for (var i = short.MinValue; i < short.MaxValue; i++) Assert.Equal(i.ToGuid().ToInt16(), i);
    }

    [Fact]
    public void EqualInt32Test()
    {
        for (var i = int.MinValue; i < int.MaxValue; i++) Assert.Equal(i, i.ToGuid().ToInt32());
    }

    [Fact]
    public void EqualInt64Test()
    {
        Assert.Equal(long.MinValue, long.MinValue.ToGuid().ToInt64());
        Assert.Equal(long.MaxValue, long.MaxValue.ToGuid().ToInt64());
    }

    [Fact]
    public void RandomGuidTest()
    {
        Assert.Equal(-4521335071095175065, new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToInt64());
    }

    [Fact]
    public void GuidStringWithoutDashesTest()
    {
        Assert.Equal("6748db38b5fd40c18066c0a0f1733377",
            new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToStringWithoutDashes());
    }
}