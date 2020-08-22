#if _dev_ || _metrix_

using UnityEngine;
using MetrixSDK;
using System.Collections.Generic;

namespace Narin.Unity.Analytics {
    public partial class AnalyticsBuilder {

        private class MetrixService : SingletonMono<MetrixService>, IAnalyticsService {
            private string _publicKey = null;
            private Dictionary<EventType, Dictionary<string, string>> _slugTable;
            public void SetNeededParameter(string publicKey, Dictionary<EventType, Dictionary<string, string>> slugTable) {
                _publicKey = publicKey;
                _slugTable = slugTable;
            }

            public void Init() {
                var config = new MetrixConfig(_publicKey);
                Metrix.OnCreate(config);
                Debug.Log("Metrix Initialized");
            }

            public void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType) {
                Metrix.NewRevenue(_slugTable[EventType.Revenue]["purchased"], amount, GetMetrixCurrencyCode(currency), itemType +'.'+itemId);
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

            public void ResourceEvent(ResourceFlowType flowType, string virtualCurrency, float amount, string itemType, string itemId, float wholeAmount = -1) {
                Debug.LogWarning("Metrix does not support 'Resource' events");
                //Metrix.NewEvent(_slugTable[EventType.Resource][virtualCurrency], new Dictionary<string, string> {
                //     {"Item", itemType + '.' + itemId }
                //    ,{"Value", wholeAmount.ToString() }
                //});
                //
                //if(flowType == ResourceFlowType.Source)
                //    Debug.Log("Metrix Sent Resource Source Event");
                //if(flowType == ResourceFlowType.Sink)
                //    Debug.Log("Metrix Sent Resource Sink Event");
            }
        }
    }
}

#endif