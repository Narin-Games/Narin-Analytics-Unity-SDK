#if _dev_ || _gameanalytics_

using UnityEngine;
using GameAnalyticsSDK;
using System.Runtime.InteropServices;

namespace Narin.Unity.Analytics {
    public partial class AnalyticsBuilder {

        private class GameAnalyticsService : SingletonMono<GameAnalyticsService>, IAnalyticsService {
            public void Init(string publicKey = null) {
                GameAnalytics.Initialize();
                Debug.Log("GameAnalytics Initialized");
            }

            public void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType, string slug=null) {
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

            public int ConvertDollarToCent (float dollar) {
                return Mathf.RoundToInt(dollar*100);
            }
        }
    }
}

#endif