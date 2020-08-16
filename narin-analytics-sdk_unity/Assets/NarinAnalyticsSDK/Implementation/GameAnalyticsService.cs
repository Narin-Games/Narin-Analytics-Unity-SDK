#if _dev_ || _gameanalytics_

using UnityEngine;
using GameAnalyticsSDK;

namespace Narin.Unity.Analytics {
    public partial class AnalyticsBuilder {

        private class GameAnalyticsService : SingletonMono<GameAnalyticsService>, IAnalyticsService {
            public void Init(string publicKey = null) {
                GameAnalytics.Initialize();
                Debug.Log("GameAnalytics Initialized");
            }

            public void RevenueEvent(Currency currency, int amount, string itemType, string itemId, string cartType, string slug=null) {
                GameAnalytics.NewBusinessEvent(currency, amount, itemType, itemId, cartType);
            }
        }
    }
}

#endif