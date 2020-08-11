#if _dev_ || _fireanalytics_

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narin.Unity.Analytics {
    public partial class AnalyticsBuilder {

        private class FirebaseAnalyticsService : SingletonMono<FirebaseAnalyticsService>, IAnalyticsService {
            
            public void Init(string publicKey = null) {
                Debug.Log("Firebase Analytics Initialized");
            }
        }

    }
}

#endif