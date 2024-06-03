using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreFilms.entities.convertions
{
    public class CurrencySymbol: ValueConverter<Currency, string>
    {
        public CurrencySymbol():base(
            value => StringCurrencyMapping(value),
            value => CurrencyStringMapping(value)
            )
        {
            
        }

        private static string StringCurrencyMapping(Currency value)
        {
            return value switch
            {
                Currency.NewSun => "S/.",
                Currency.Dollar => "$",
                Currency.Euro => "€",
                _ => ""
            };
        }

        private static Currency CurrencyStringMapping(string value)
        {
            return value switch
            {
                "S/." => Currency.NewSun,
                "$" => Currency.Dollar,
                "€" => Currency.Euro,
                _ => Currency.Unknown
            };
        }
    }
}
