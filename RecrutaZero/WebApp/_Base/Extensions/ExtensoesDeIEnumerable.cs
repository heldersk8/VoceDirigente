using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RecrutaZero.WebApp._Base.Extensions
{
    public static class ExtensoesDeIEnumerable
    {
        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> texto, Func<T, int> valor, int valorSelecionado = 0,
                                                                  Func<IEnumerable<T>, IOrderedEnumerable<T>> expressaoDeOrdenacao = null, ItemDefault itemDefault = null)
        {
            Func<T, bool> expressaoDeSelecao = f => valor(f) == valorSelecionado;
            Func<T, string> valorComoString = f => valor(f).ToString();
            return CriarSelectListItems(enumerable, texto, valorComoString, expressaoDeSelecao, expressaoDeOrdenacao, itemDefault);
        }

        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, Func<T, string> texto, Func<T, string> valor, Func<T, bool> expressaoDeSelecao = null,
                                                                  Func<IEnumerable<T>, IOrderedEnumerable<T>> expressaoDeOrdenacao = null, ItemDefault itemDefault = null)
        {
            return CriarSelectListItems(enumerable, texto, valor, expressaoDeSelecao, expressaoDeOrdenacao, itemDefault);
        }

        private static IEnumerable<SelectListItem> CriarSelectListItems<T>(IEnumerable<T> enumerable, Func<T, string> texto, Func<T, string> valor, Func<T, bool> expressaoDeSelecao,
                                                                           Func<IEnumerable<T>, IOrderedEnumerable<T>> expressaoDeOrdenacao, ItemDefault itemDefault)
        {
            List<SelectListItem> items;

            if (expressaoDeOrdenacao != null)
                items = expressaoDeOrdenacao(enumerable).Select(f => new SelectListItem { Text = texto(f), Value = valor(f), Selected = (expressaoDeSelecao != null && expressaoDeSelecao(f)) }).ToList();
            else
                items = enumerable.Select(f => new SelectListItem { Text = texto(f), Value = valor(f), Selected = (expressaoDeSelecao != null && expressaoDeSelecao(f)) }).ToList();

            if (itemDefault != null)
                items.Insert(0, new SelectListItem { Text = itemDefault.Texto, Value = itemDefault.Valor });

            return items;
        }
    }
}