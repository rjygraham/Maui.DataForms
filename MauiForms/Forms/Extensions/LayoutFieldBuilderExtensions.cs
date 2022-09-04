namespace MauiForms.Forms.Extensions;

public static class LayoutFieldBuilderExtensions
{
    public static TBuilder WithGridLayout<TBuilder>(this TBuilder builder, int? gridRow = null, int? gridColumn = null, int? gridRowSpan = 1, int? gridColumnSpan = 1)
        where TBuilder : ILayoutFieldBuilder
    {
        builder.GridRow = gridRow;
        builder.GridColumn = gridColumn;
        builder.GridRowSpan = gridRowSpan;
        builder.GridColumnSpan = gridColumnSpan;

        return builder;
    }
}
