#if _dev_ || _gameanalytics_

using UnityEngine;
using GameAnalyticsSDK;

namespace Narin.Unity.Analytics {

    public partial class AnalyticsBuilder {
        private class GameAnalyticsService : SingletonMono<GameAnalyticsService>, IAnalyticsService {
            public void Init() {
                GameAnalytics.Initialize();
                Debug.Log("GameAnalytics Initialized");
            }

            public void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType) {
                int convertedAmount;

                if(currency.CurrencyCodeNum == Currency.USD) {
                    convertedAmount = ConvertDollarToCent(amount);
                }
                else {
                    convertedAmount = Mathf.RoundToInt(amount);
                }

                GameAnalytics.NewBusinessEvent(currency, convertedAmount, itemType, itemId, cartType);
                Debug.Log("GameAnalytics Sent Business Event");
            }

            public void ResourceEvent(ResourceFlowType flowType, string virtualCurrency, float amount, string itemType, string itemId, float wholeAmount = -1) {
                GameAnalytics.NewResourceEvent(ConvertToGAFlowType(flowType), virtualCurrency, amount, itemType, itemId);
            }

            public GAResourceFlowType ConvertToGAFlowType (ResourceFlowType flowType) {
                GAResourceFlowType ret = GAResourceFlowType.Undefined;

                if(flowType == ResourceFlowType.Source)
                    ret = GAResourceFlowType.Source;
                if(flowType == ResourceFlowType.Sink)
                    ret = GAResourceFlowType.Sink;

                return ret;
            }

            private int ConvertDollarToCent (float dollar) {
                return Mathf.RoundToInt(dollar*100);
            }
        }
    }
}

#endif