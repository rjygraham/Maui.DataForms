using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiForms.Forms.Extensions;

public static class EntryFormFieldBuilderExtensions
{
    public static IEditorFormFieldBuilder<TModel> WithCharacterSpacing<TModel>(this IEditorFormFieldBuilder<TModel> builder, double characterSpacing)
    {

        return builder;
    }
}
