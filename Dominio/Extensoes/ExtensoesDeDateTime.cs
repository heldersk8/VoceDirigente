using System;

namespace Dominio.Extensoes
{
    public static class ExtensoesDeDateTime
    {
        public static DateTime PrimeiroDiaDoMes(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, 1);
        }

        public static DateTime ColocarDataNoUltimoDiaComercialDoMes(this DateTime data)
        {
            var diaComercialDoMes = data.Month == 2 ? (DateTime.IsLeapYear(data.Year) ? 29 : 28) : 30;
            return new DateTime(data.Year, data.Month, diaComercialDoMes);
        }

        public static DateTime ColocarDataNoProximoMesNoDia(this DateTime data, int dia)
        {
            var mes = data.Month == 12 ? 1 : data.Month + 1;
            var ano = data.Month == 12 ? data.Year + 1 : data.Year;
            dia = dia > 28 && mes == 2 ? 28 : dia;
            return new DateTime(ano, mes, dia);
        }

        public static DateTime ColocarDataNoDia(this DateTime data, int dia)
        {
            return new DateTime(data.Year, data.Month, dia);
        }

        public static DateTime PrimeiroDiaDoTrimestre(this DateTime data)
        {
            var mesDoTrimestre = ((data.Month - 1) / 3) * 3 + 1;

            return new DateTime(data.Year, mesDoTrimestre, 1);
        }

        public static bool NoPeriodo(this DateTime dataAComparar, DateTime? dataInicial, DateTime? dataFinal)
        {
            var comparacaoInferior = true;
            var comparacaoSuperior = true;

            if (dataInicial.HasValue)
                comparacaoInferior = (dataAComparar >= dataInicial.Value);

            if (dataFinal.HasValue)
                comparacaoSuperior = (dataAComparar <= dataFinal.Value);

            return (comparacaoInferior && comparacaoSuperior);
        }

        public static bool DataValida(this DateTime date)
        {
            var dataMinima = new DateTime(1950, 01, 01);
            return date > dataMinima;
        }

        public static bool DataFutura(this DateTime date)
        {
            return date > DateTime.Today;
        }

        public static bool CompararMesEAno(this DateTime date, DateTime dataASerComparada)
        {
            var date1 = date.PrimeiroDiaDoMes();
            var date2 = dataASerComparada.PrimeiroDiaDoMes();

            return date1 == date2;
        }

        public static DateTime AdicionaUmMes(this DateTime data)
        {
            return data.AddMonths(1);
        }

        public static DateTime ColocarNoMesAnteriorNoDiaPrimeiro(this DateTime data)
        {
            return data.AddMonths(-1).PrimeiroDiaDoMes();
        }

        public static DateTime ColocarNoMes(this DateTime data, int mes)
        {
            return new DateTime(data.Year, mes, data.Day);
        }

        public static DateTime ColocarDataNoProximoMes(this DateTime data)
        {
            var mes = data.Month == 12 ? 1 : data.Month + 1;
            var ano = data.Month == 12 ? data.Year + 1 : data.Year;
            return new DateTime(ano, mes, data.Day);
        }

        public static DateTime ColocarNoUltimoDiaDoMes(this DateTime data)
        {
            var ultimoDiaDoMes = DateTime.DaysInMonth(data.Year, data.Month);

            return new DateTime(data.Year, data.Month, ultimoDiaDoMes);
        }

        public static int DiferencaEmMeses(this DateTime data, DateTime dataFinal)
        {
            return ((data.Year - dataFinal.Year) * 12) + data.Month - dataFinal.Month + 1;
        }

        public static int DaysInMonth(this DateTime data)
        {
            return DateTime.DaysInMonth(data.Year, data.Month);
        }
    }
}
