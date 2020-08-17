#if _dev_ || _metrix_

using UnityEngine;
using MetrixSDK;

namespace Narin.Unity.Analytics {
    public partial class AnalyticsBuilder {

        private class MetrixService : SingletonMono<MetrixService>, IAnalyticsService {

            public void Init(string publicKey) {
                var config = new MetrixConfig(publicKey);
                Metrix.OnCreate(config);
                Debug.Log("Metrix Initialized");
            }

            public void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType, string slug = null) {
                Metrix.NewRevenue(slug, amount, GetMetrixCurrencyCode(currency), itemType +'.'+itemId);
                Debug.Log("Metrix Sent Business Event");
            }

            private int GetMetrixCurrencyCode (int currencyCodeNum) {
                int ret = -1;

                if(currencyCodeNum == Currency.IRR) ret = 0;
                else
                if(currencyCodeNum == Currency.USD) ret = 1;
                else
                if(currencyCodeNum == Currency.EUR) ret = 3;
                
                return ret;
            }
        }
    }
}

#endif