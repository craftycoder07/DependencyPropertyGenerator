using ProjectControls.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectControls
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum RegisterMethodOverload
    {
        [Description("No Argument")]
        Basic = 1,
        [Description("PropertyMetadata")]
        WithPropertyMetadata = 2,
        [Description("PropertyMetadata, Validation Callback")]
        WithPropertyMetadataAndCallback = 3
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FrameworkPropertyMetadataOverload
    {
        [Description("no argument")]
        Basic = 1,
        [Description("default value")]
        DefaultValue = 2,
        [Description("default value, frameworkmetadata option")]
        DefaultValueMetadataOption = 3,
        [Description("default value,frameworkmetadata option, propertyChanged callback")]
        DefaultValueMetadataOptionPropertyChanged = 4,
        [Description("default value,frameworkmetadata option, propertyChanged callback, coerce")]
        DefaultValueMetadataOptionPropertyChangedCoerce = 5,
        [Description("default value,frameworkmetadata option, propertyChanged callback, coerce, animation")]
        DefaultValueMetadataOptionPropertyChangedCoerceAnimation = 6,
        [Description("default value,frameworkmetadata option, propertyChanged callback, coerce, animation, update trigger")]
        DefaultValueMetadataOptionPropertyChangedCoerceAnimationUpdateTrigger = 7,
        [Description("default value, propertyChanged")]
        DefaultValuePropertyChanged = 8,
        [Description("default value, propertyChanged, coerce")]
        DefaultValuePropertyChangedCoerce = 9,
        [Description("propertyChanged")]
        PropertyChanged = 10,
        [Description("propertyChanged, coerce")]
        PropertyChangedCoerce = 11
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FrameworkPropertyMetadataOptions
    {
        AffectsArrange = 1,
        AffectsMeasure = 2,
        AffectsParentArrange = 3,
        AffectsParentMeasure = 4,
        AffectsRender = 5,
        BindsTwoWayByDefault = 6,
        Inherits = 7,
        Journal = 8,
        None = 9,
        NotDataBindable = 10,
        OverridesInheritanceBehavior = 11,
        SubPropertiesDoNotAffectRender = 12
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BooleanEnum
    {
        False = 0,
        True = 1
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum UpdateSourceTrigger
    {
        Default = 1,
        Explicit = 2,
        LostFocus = 3,
        PropertyChanged = 4
    }

    class Enumerations
    {

    }
}
