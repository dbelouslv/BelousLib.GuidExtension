namespace BelousLib.GuidExtension.UnitTests;

public class ExtensionTest
{
    [Fact]
    public void ToUInt16Success()
    {
        for (var i = ushort.MinValue; i < ushort.MaxValue; i++) Assert.Equal(i, i.ToGuid().ToUInt16());
    }

    [Fact]
    public void ToUInt32Success()
    {
        Assert.Equal(uint.MinValue, uint.MinValue.ToGuid().ToUInt32());
        Assert.Equal(uint.MaxValue, uint.MaxValue.ToGuid().ToUInt32());
        Assert.Equal(uint.MaxValue / 2, (uint.MaxValue / 2 ).ToGuid().ToUInt32());
        Assert.Equal(uint.MaxValue / 6, (uint.MaxValue / 6 ).ToGuid().ToUInt32());
        Assert.Equal(uint.MaxValue / 10, (uint.MaxValue / 10 ).ToGuid().ToUInt32());
    }

    [Fact]
    public void ToUInt64Success()
    {
        Assert.Equal(ulong.MinValue, ulong.MinValue.ToGuid().ToUInt64());
        Assert.Equal(ulong.MaxValue, ulong.MaxValue.ToGuid().ToUInt64());
    }

    [Fact]
    public void ToInt16Success()
    {
        for (var i = short.MinValue; i < short.MaxValue; i++) Assert.Equal(i.ToGuid().ToInt16(), i);
    }

    [Fact]
    public void ToInt32Success()
    {
        Assert.Equal(int.MinValue, int.MinValue.ToGuid().ToInt32());
        Assert.Equal(int.MaxValue, int.MaxValue.ToGuid().ToInt32());
        Assert.Equal(int.MaxValue / 2, (int.MaxValue / 2).ToGuid().ToInt32());
        Assert.Equal(int.MaxValue / 6, (int.MaxValue / 6).ToGuid().ToInt32());
        Assert.Equal(int.MaxValue / 10, (int.MaxValue / 10).ToGuid().ToInt32());
    }

    [Fact]
    public void ToInt64Success()
    {
        Assert.Equal(long.MinValue, long.MinValue.ToGuid().ToInt64());
        Assert.Equal(long.MaxValue, long.MaxValue.ToGuid().ToInt64());
    }

    [Fact]
    public void ToSingleSuccess()
    {
        Assert.Equal(float.MinValue, float.MinValue.ToGuid().ToSingle());
        Assert.Equal(float.MaxValue / 2, (float.MaxValue / 2).ToGuid().ToSingle());
        Assert.Equal(float.MaxValue, float.MaxValue.ToGuid().ToSingle());
    }

    [Fact]
    public void ToDoubleSuccess()
    {
        Assert.Equal(double.MinValue, double.MinValue.ToGuid().ToDouble());
        Assert.Equal(double.MaxValue / 2, (double.MaxValue / 2).ToGuid().ToDouble());
        Assert.Equal(double.MaxValue, double.MaxValue.ToGuid().ToDouble());
    }

    [Fact]
    public void ToStringGuidFromGuidSuccess()
    {
        Assert.Equal(new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToString(), new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToStringGuidFromGuid());
    }

    [Fact]
    public void ToStringGuidFromGuidWithoutDashesSuccess()
    {
        Assert.Equal("6748db38b5fd40c18066c0a0f1733377", new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToStringGuidFromGuidWithoutDashes());
    }

    [Fact]
    public void ToGuidFromStringGuidSuccess()
    {
        Assert.Equal(new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377"), "6748db38b5fd40c18066c0a0f1733377".ToGuidFromStringGuid());
    }

    [Fact]
    public void ToRandomGuidSuccess()
    {
        Assert.Equal(4666210788896725816, new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToInt64());
    }

    [Fact]
    public void ToGuidFromStringSuccess()
    {
        const string title = "Universal Studio";

        Assert.Equal(title, title.ToGuid().ToStringFromGuid());
    }
}