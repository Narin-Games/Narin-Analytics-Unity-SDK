using System.Collections.Generic;
using UnityEngine;

namespace Narin.Unity.Analytics {
    public enum AnalyticsService {
        FirebaseAnalytics, Metrix, GameAnalytics
    }

    public enum ResourceFlowType {
        Sink, Source
    }

    public enum EventType {
        Revenue, Resource
    }

    public partial class AnalyticsBuilder {
        public static IAnalyticsServices CurrentAnalyticsServices {get; private set;}

        private Dictionary<AnalyticsService, string> _publicKeys = new Dictionary<AnalyticsService, string>();
        private Dictionary<AnalyticsService, Dictionary<string, string>> _revenueSlugTable  = new Dictionary<AnalyticsService, Dictionary<string, string>>();
        private Dictionary<AnalyticsService, Dictionary<string, string>> _resourceSlugTable = new Dictionary<AnalyticsService, Dictionary<string, string>>();

        public void SetPublicKey(AnalyticsService service, string publicKey) {
            _publicKeys.Add(service, publicKey);
        }

        public void SetRevenueSlug(AnalyticsService service, string slug) {
            SetEventSlug(_revenueSlugTable, service, "purchased", slug);
        }

        public void SetResourceSlug(AnalyticsService service, string virtualCurrency, string slug) {
            SetEventSlug(_resourceSlugTable, service, virtualCurrency, slug);
        }

        public IAnalyticsServices BuildAndAttach(MonoBehaviour mono) {
            AnalyticsServices ret = null;
            
            ret = mono.gameObject.AddComponent<AnalyticsServices>();

            #if _dev_ || _fireanalytics_ 
            ret.RegisterService(
                 AnalyticsService.FirebaseAnalytics
                ,mono.gameObject.AddComponent<FirebaseAnalyticsService>()
                );
            #endif

            #if _dev_ || _metrix_
            MetrixService metrix;
            ret.RegisterService(
                 AnalyticsService.Metrix
                ,metrix = mono.gameObject.AddComponent<MetrixService>()
                );

            var slugTable = new Dictionary<EventType, Dictionary<string, string>>() {
                 {EventType.Revenue , _revenueSlugTable[AnalyticsService.Metrix] }
                ,{EventType.Resource, _revenueSlugTable[AnalyticsService.Metrix] }
            };

            metrix.SetNeededParameter(_publicKeys[AnalyticsService.Metrix], slugTable);
            #endif

            #if _dev_ || _gameanalytics_
            ret.RegisterService(
                 AnalyticsService.GameAnalytics
                ,mono.gameObject.AddComponent<GameAnalyticsService>()
                );
            #endif

            CurrentAnalyticsServices = ret;
            return ret;
        }

        private void SetEventSlug(Dictionary<AnalyticsService, Dictionary<string, string>> _slugTable, AnalyticsService service, string parameter, string slug) {
            if (_slugTable.ContainsKey(service)){
                _slugTable[service].Add(parameter, slug);
            }
            else {
                _slugTable.Add(service, new Dictionary<string, string>());
                _slugTable[service].Add(parameter, slug);
            }
        }
    }
}