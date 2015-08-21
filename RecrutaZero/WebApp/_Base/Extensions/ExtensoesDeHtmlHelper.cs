using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RecrutaZero.WebApp._Base.Extensions
{
    public static class ExtensoesDeHtmlHelper
    {
        public static IHtmlString Stringify(this HtmlHelper htmlHelper, object model)
        {
            return htmlHelper.Raw(Json.Encode(model));
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> modelExpression, ItemDefault itemDefault = null)
        {
            itemDefault = itemDefault ?? ItemDefault.ComTextoEValoresVazios();

            var typeOfProperty = modelExpression.ReturnType;

            if (!typeOfProperty.IsEnum)
                throw new ArgumentException(String.Format("Type {0} is not an enum", typeOfProperty));

            var items = Enum.GetValues(typeOfProperty).Cast<Enum>().Select(x => new SelectListItem { Selected = false, Text = x.ToDescription(), Value = x.ToString() }).ToList();

            if (itemDefault != null)
                items.Insert(0, new SelectListItem { Text = itemDefault.Texto, Value = itemDefault.Valor });

            return htmlHelper.DropDownListFor(modelExpression, items);
        }
    }
}