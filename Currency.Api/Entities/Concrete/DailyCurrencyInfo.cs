using Currency.Api.Entities.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.Entities.Concrete
{
    public class DailyCurrencyInfo : IEntity
    {
        [JsonProperty(PropertyName = "Developer")]
        public Developer DevInfo{ get; set; }

        [JsonProperty(PropertyName = "TCMB_AnlikKurBilgileri")]
        public List<TcmbCurrency> Currencies { get; set; }
    }
}
