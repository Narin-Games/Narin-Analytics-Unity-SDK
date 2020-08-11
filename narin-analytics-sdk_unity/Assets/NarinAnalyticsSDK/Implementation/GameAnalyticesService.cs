#if _dev_ || _gameanalytics_

using UnityEngine;
using GameAnalyticsSDK;

namespace Narin.Unity.Analytics {
    public partial class AnalyticsBuilder {

        private class GameAnalyticesService : SingletonMono<GameAnalyticesService>, IAnalyticsService {
            public void Init(string publicKey = null) {
                GameAnalytics.Initialize();
                Debug.Log("GameAnalytics Initialized");
            }
        }
    }
}

#endif