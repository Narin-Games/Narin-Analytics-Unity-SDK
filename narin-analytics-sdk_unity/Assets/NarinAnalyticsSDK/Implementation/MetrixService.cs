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

        }

    }
}

#endif