using System.Collections.Generic;
using UnityEngine;

namespace Narin.Unity.Analytics {
    public class AnalyticsServices: MonoBehaviour, IAnalyticsServices {

        private Dictionary<AnalyticsService, IAnalyticsService> _services = new Dictionary<AnalyticsService, IAnalyticsService>();
        private Dictionary<AnalyticsService, string> _publicKeys = new Dictionary<AnalyticsService, string>();

        public void RegisterService(AnalyticsService service, IAnalyticsService serviceManager, string publicKey = null) {
            _services.Add(service, serviceManager);
            _publicKeys.Add(service, publicKey);
        }

        public void Init(string publicKey = null) {
            foreach(var service in _services.Keys) {
                _services[service].Init(_publicKeys[service]);
            }
        }

        public IAnalyticsService GetService(AnalyticsService service) {
            return _services[service];
        }

        public IAnalyticsServices GetService(params AnalyticsService[] services) {
            AnalyticsServices ret = new AnalyticsServices();

            foreach(var service in services) {
                ret.RegisterService(service, _services[service], _publicKeys[service]);
            }

            return ret;
        }

        public void RevenueEvent(Currency currency, int amount, string itemType, string itemId, string cartType, string slug = null) {
            foreach(var service in _services.Keys) {
                _services[service].RevenueEvent(currency, amount, itemType, itemId, cartType, slug);
            }
        }
    }
}