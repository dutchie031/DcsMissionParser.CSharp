using System.ComponentModel;
using System.Globalization;
using DcsMissionParser.Net.Annotations;
using DcsMissionParser.Net.Objects.Coalitions.Countries.Groups;

namespace DcsMissionParser.Net.Tests;

[TestClass]
public class StringEnumTypeConverterTests
{
    private StringEnumTypeConverter _converter = null!;

    [TestInitialize]
    public void Setup()
    {
        _converter = new StringEnumTypeConverter();
    }

    [TestMethod]
    public void Converter_CanConvertFrom_String()
    {
        var canConvert = _converter.CanConvertFrom(sourceType: typeof(string));

        Assert.IsTrue(canConvert);
    }

    [TestMethod]
    public void Converter_CanConvertFrom_OtherTypes_DelegatesToBase()
    {
        var canConvert = _converter.CanConvertFrom(sourceType: typeof(int));

        Assert.IsFalse(canConvert);
    }

    [TestMethod]
    public void Converter_CanConvertTo_String()
    {
        var canConvert = _converter.CanConvertTo(destinationType: typeof(string));

        Assert.IsTrue(canConvert);
    }

    [TestMethod]
    public void Converter_CanConvertTo_OtherTypes_DelegatesToBase()
    {
        var canConvert = _converter.CanConvertTo(destinationType: typeof(int));

        Assert.IsFalse(canConvert);
    }

    [TestMethod]
    public void ConvertFrom_ValidStringValue_ReturnsMatchingStaticInstance()
    {
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        var result = _converter.ConvertFrom(context, CultureInfo.InvariantCulture, "CAP");

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(PlaneTasking));
        Assert.AreSame(PlaneTasking.CAP, result);
    }

    [TestMethod]
    public void ConvertFrom_MultiWordStringValue_ReturnsMatchingStaticInstance()
    {
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        var result = _converter.ConvertFrom(context, CultureInfo.InvariantCulture, "Antiship Strike");

        Assert.IsNotNull(result);
        Assert.AreSame(PlaneTasking.AntishipStrike, result);
    }

    [TestMethod]
    public void ConvertFrom_CaseInsensitive_ReturnsMatchingStaticInstance()
    {
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        var result = _converter.ConvertFrom(context, CultureInfo.InvariantCulture, "cap");

        Assert.IsNotNull(result);
        Assert.AreSame(PlaneTasking.CAP, result);
    }

    [TestMethod]
    public void ConvertFrom_UnknownStringValue_ThrowsNotSupportedException()
    {
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        var exception = Assert.Throws<NotSupportedException>(() =>
        {
            _converter.ConvertFrom(context, CultureInfo.InvariantCulture, "InvalidTasking");
        });

        Assert.IsTrue(exception.Message.Contains("Unknown") && exception.Message.Contains("InvalidTasking"));
    }

    [TestMethod]
    public void ConvertFrom_EmptyString_ThrowsArgumentException()
    {
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            _converter.ConvertFrom(context, CultureInfo.InvariantCulture, "");
        });

        Assert.Contains("null or whitespace", exception.Message);
    }

    [TestMethod]
    public void ConvertFrom_WhitespaceString_ThrowsArgumentException()
    {
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            _converter.ConvertFrom(context, CultureInfo.InvariantCulture, "   ");
        });

        Assert.Contains("null or whitespace", exception.Message);
    }

    [TestMethod]
    public void ConvertFrom_NonStringValue_ThrowsFormatException()
    {
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        var exception = Assert.Throws<NotSupportedException>(() =>
        {
            _converter.ConvertFrom(context, CultureInfo.InvariantCulture, 42);
        });
    }

    [TestMethod]
    public void ConvertFrom_WithoutContext_ThrowsFormatException()
    {
        var exception = Assert.Throws<NotSupportedException>(() =>
        {
            _converter.ConvertFrom(context: null, CultureInfo.InvariantCulture, "CAP");
        });
    }

    [TestMethod]
    public void ConvertTo_StringEnumToString_ReturnsValue()
    {
        var result = _converter.ConvertTo(context: null, CultureInfo.InvariantCulture, PlaneTasking.CAP, typeof(string));

        Assert.AreEqual("CAP", result);
    }

    [TestMethod]
    public void ConvertTo_MultiWordStringEnumToString_ReturnsValue()
    {
        var result = _converter.ConvertTo(context: null, CultureInfo.InvariantCulture, PlaneTasking.AntishipStrike, typeof(string));

        Assert.AreEqual("Antiship Strike", result);
    }

    [TestMethod]
    public void ConvertTo_ToNonStringType_ThrowsNotSupportedException()
    {
        var exception = Assert.Throws<NotSupportedException>(() =>
        {
            _converter.ConvertTo(context: null, CultureInfo.InvariantCulture, PlaneTasking.CAP, typeof(int));
        });
    }

    [TestMethod]
    public void RoundTrip_StringEnumToStringAndBack()
    {
        var original = PlaneTasking.FighterSweep;
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        // Convert to string
        var stringValue = _converter.ConvertTo(null, CultureInfo.InvariantCulture, original, typeof(string));
        Assert.IsNotNull(stringValue);

        // Convert back
        var recovered = _converter.ConvertFrom(context, CultureInfo.InvariantCulture, stringValue);

        Assert.AreSame(original, recovered);
    }

    [TestMethod]
    public void Converter_WorksWithDifferentStringEnumSubclasses()
    {
        // This test ensures the converter is truly generic
        var context = CreatePropertyDescriptorContext(typeof(PlaneTasking));

        var result = _converter.ConvertFrom(context, CultureInfo.InvariantCulture, "Transport");

        Assert.IsNotNull(result);
        Assert.AreSame(PlaneTasking.Transport, result);
    }

    /// <summary>
    /// Helper method to create a mock ITypeDescriptorContext with a PropertyDescriptor
    /// that returns the specified property type.
    /// </summary>
    private static ITypeDescriptorContext CreatePropertyDescriptorContext(Type propertyType)
    {
        var mockDescriptor = new MockPropertyDescriptor(propertyType);
        return new MockTypeDescriptorContext(mockDescriptor);
    }

    /// <summary>
    /// Mock implementation of ITypeDescriptorContext for testing.
    /// </summary>
    private class MockTypeDescriptorContext : ITypeDescriptorContext
    {
        private readonly PropertyDescriptor _propertyDescriptor;

        public MockTypeDescriptorContext(PropertyDescriptor propertyDescriptor)
        {
            _propertyDescriptor = propertyDescriptor;
        }

        public IContainer Container => throw new NotImplementedException();
        public object Instance => throw new NotImplementedException();
        public PropertyDescriptor PropertyDescriptor => _propertyDescriptor;

        public object GetService(Type serviceType) => throw new NotImplementedException();
        public void OnComponentChanged() => throw new NotImplementedException();
        public bool OnComponentChanging() => throw new NotImplementedException();
    }

    /// <summary>
    /// Mock implementation of PropertyDescriptor for testing.
    /// </summary>
    private class MockPropertyDescriptor : PropertyDescriptor
    {
        private readonly Type _propertyType;

        public MockPropertyDescriptor(Type propertyType)
            : base("MockProperty", Array.Empty<Attribute>())
        {
            _propertyType = propertyType;
        }

        public override Type PropertyType => _propertyType;
        public override Type ComponentType => throw new NotImplementedException();
        public override bool IsReadOnly => throw new NotImplementedException();

        public override object GetValue(object? component) => throw new NotImplementedException();
        public override void SetValue(object? component, object? value) => throw new NotImplementedException();
        public override void ResetValue(object? component) => throw new NotImplementedException();
        public override bool CanResetValue(object? component) => throw new NotImplementedException();
        public override bool ShouldSerializeValue(object? component) => throw new NotImplementedException();
    }
}
