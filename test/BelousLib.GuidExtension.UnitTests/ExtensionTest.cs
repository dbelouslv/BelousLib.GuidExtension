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
        Assert.Equal(uint.MinValue, uint.MinValue.ToGuid().ToUInt32());
        Assert.Equal(uint.MaxValue, uint.MaxValue.ToGuid().ToUInt32());
        Assert.Equal(uint.MaxValue / 2, (uint.MaxValue / 2 ).ToGuid().ToUInt32());
        Assert.Equal(uint.MaxValue / 6, (uint.MaxValue / 6 ).ToGuid().ToUInt32());
        Assert.Equal(uint.MaxValue / 10, (uint.MaxValue / 10 ).ToGuid().ToUInt32());
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
        Assert.Equal(int.MinValue, int.MinValue.ToGuid().ToInt32());
        Assert.Equal(int.MaxValue, int.MaxValue.ToGuid().ToInt32());
        Assert.Equal(int.MaxValue / 2, (int.MaxValue / 2).ToGuid().ToInt32());
        Assert.Equal(int.MaxValue / 6, (int.MaxValue / 6).ToGuid().ToInt32());
        Assert.Equal(int.MaxValue / 10, (int.MaxValue / 10).ToGuid().ToInt32());
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
        Assert.Equal(4666210788896725816, new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToInt64());
    }

    [Fact]
    public void GuidStringWithoutDashesTest()
    {
        Assert.Equal("6748db38b5fd40c18066c0a0f1733377", new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToStringFromGuidWithoutDashes());
    }
}