using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyPropertyGenerator
{
    public enum ResiterMethodOverload
    {
        Basic = 1,
        WithPropertyMetadata = 2,
        WithPropertyMetadataAndCallback = 3
    }

    public enum FrameworkPropertyMetadataOverload
    {
        Basic = 1,
        DefaultValue = 2,
        DefaultValueMetadataOption = 3,
        DefaultValueMetadataOptionPropertyChanged = 4,
        DefaultValueMetadataOptionPropertyChangedCoerce = 5,
        DefaultValueMetadataOptionPropertyChangedCoerceAnimation = 6,
        DefaultValueMetadataOptionPropertyChangedCoerceAnimationUpdateTrigger = 7,
        DefaultValuePropertyChanged = 8,
        DefaultValuePropertyChangedCoerce = 9,
        PropertyChanged = 10,
        PropertyChangedCoerce = 11
    }

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

    class Enumerations
    {

    }
}
