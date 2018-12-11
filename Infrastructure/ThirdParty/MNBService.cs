using System.Globalization;
using System.Threading.Tasks;
using MNBService;

namespace Infrastructure.ThirdParty
{
    /// <summary>
    /// Magyar Nemzeti Bank web servicet használó statikus osztály
    /// </summary>
    public static class MNBService
    {
        /// <summary>
        /// Aktuális árfolyam lekérdezése
        /// </summary>
        public static async Task<decimal> GetCurrentExchangeRate(string currency)
        {
            MNBArfolyamServiceSoapClient client = new MNBArfolyamServiceSoapClient();

            await client.OpenAsync();
            GetCurrentExchangeRatesResponse response = await client.GetCurrentExchangeRatesAsync(new GetCurrentExchangeRatesRequestBody());
            await client.CloseAsync();

            return GetCurrentExchangeRateFromString(currency, response.GetCurrentExchangeRatesResponse1.GetCurrentExchangeRatesResult);
        }

        private static decimal GetCurrentExchangeRateFromString(string currency, string str)
        {
            var searchstr = "curr=\"" + currency + "\">";
            str = str.Substring(str.IndexOf(searchstr) + searchstr.Length);
            str = str.Substring(0, str.IndexOf("<")).Replace(",", ".");

            return decimal.Parse(str, CultureInfo.InvariantCulture);
        }
    }
}
