using Currency.Api.Business.Abstract;
using Currency.Api.DataAccess.Abstract;
using Currency.Api.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.Business.Concrete
{
    public class DailyCurrencyInfoManager : IDailyCurrencyInfoService
    {
        private IDailyCurrencyInfoDal dailyCurrencyInfoDal;

        public DailyCurrencyInfoManager(IDailyCurrencyInfoDal dailyCurrencyInfoDal)
        {
            this.dailyCurrencyInfoDal = dailyCurrencyInfoDal;
        }

        public DailyCurrencyInfo GetCurrencies()
        {
            return dailyCurrencyInfoDal.Get("http://hasanadiguzel.com.tr/api/kurgetir");
        }

        public Task<DailyCurrencyInfo> GetCurrenciesAsync()
        {
            return Task.Run(()=> {
                return GetCurrencies();
            });
        }
    }
}
