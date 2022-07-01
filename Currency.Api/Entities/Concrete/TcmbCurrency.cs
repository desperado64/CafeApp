using Currency.Api.Entities.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.Entities.Concrete
{
    public class TcmbCurrency : IEntity
    {
        [JsonProperty(PropertyName = "Isim")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "CurrencyName")]
        public string CurrencyName { get; set; }

        [JsonProperty(PropertyName = "ForexBuying")]
        public string ForexBuying { get; set; }

        [JsonProperty(PropertyName = "ForexSelling")]
        public string ForexSelling { get; set; }

        [JsonProperty(PropertyName = "BanknoteBuying")]
        public string BanknoteBuying { get; set; }

        [JsonProperty(PropertyName = "BanknoteSelling")]
        public string BanknoteSelling { get; set; }

        [JsonProperty(PropertyName = "CrossRateUSD")]
        public string CrossRateUSD { get; set; }

        [JsonProperty(PropertyName = "CrossRateOther")]
        public string CrossRateOther { get; set; }

    }
}
