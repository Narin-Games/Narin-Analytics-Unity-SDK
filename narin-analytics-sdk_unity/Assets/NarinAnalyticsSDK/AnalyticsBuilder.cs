using MetrixSDK;
using System.Collections.Generic;
using UnityEngine;

namespace Narin.Unity.Analytics {
    public enum AnalyticsService {
        FirebaseAnalytics, Metrix, GameAnalytics
    }

    public partial class AnalyticsBuilder {
        public static AnalyticsManager CurrentAnalyticsManager {get; private set;}

        private Dictionary<AnalyticsService, string> _publicKeys = new Dictionary<AnalyticsService, string>();

        public void SetPublicKey(AnalyticsService service, string publicKey) {
            _publicKeys.Add(service, publicKey);
        }

        public AnalyticsManager BuildAndAttach(MonoBehaviour mono) {
            AnalyticsManager ret = null;
            
            ret = mono.gameObject.AddComponent<AnalyticsManager>();

            #if _dev_ || _fireanalytics_ 
            ret.RegisterService(
                 AnalyticsService.FirebaseAnalytics
                ,mono.gameObject.AddComponent<FirebaseAnalyticsService>()
                //,_publicKeys[AnalyticsService.FirebaseAnalytics]
                );
            #endif

            #if _dev_ || _metrix_
            ret.RegisterService(
                 AnalyticsService.Metrix
                ,mono.gameObject.AddComponent<MetrixService>()
                ,_publicKeys[AnalyticsService.Metrix]
                );
            #endif

            #if _dev_ || _gameanalytics_
            ret.RegisterService(
                 AnalyticsService.GameAnalytics
                ,mono.gameObject.AddComponent<GameAnalyticesService>()
                //,_publicKeys[AnalyticsService.GameAnalytics]
                );
            #endif

            CurrentAnalyticsManager = ret;
            return ret;
        }

    }
}