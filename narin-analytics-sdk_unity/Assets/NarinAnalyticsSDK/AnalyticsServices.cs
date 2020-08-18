using System.Collections.Generic;
using UnityEngine;

namespace Narin.Unity.Analytics {
    public class AnalyticsServices: MonoBehaviour, IAnalyticsServices {

        private Dictionary<AnalyticsService, IAnalyticsService> _services = new Dictionary<AnalyticsService, IAnalyticsService>();

        public void RegisterService(AnalyticsService service, IAnalyticsService serviceManager) {
            _services.Add(service, serviceManager);
        }

        public void Init() {
            foreach(var service in _services.Keys) {
                _services[service].Init();
            }
        }

        public IAnalyticsService GetService(AnalyticsService service) {
            return _services[service];
        }

        public IAnalyticsServices GetService(params AnalyticsService[] services) {
            AnalyticsServices ret = new AnalyticsServices();

            foreach(var service in services) {
                ret.RegisterService(service, _services[service]);
            }

            return ret;
        }

        public void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType) {
            foreach(var service in _services.Keys) {
                _services[service].RevenueEvent(currency, amount, itemType, itemId, cartType);
            }
        }

        public void ResourceEvent(ResourceFlowType flowType, string virtualCurrency, float amount, string itemType, string itemId, float wholeAmount = -1) {
            foreach(var service in _services.Keys) {
                _services[service].ResourceEvent(flowType, virtualCurrency, amount, itemType, itemId, wholeAmount);
            }
        }
    }
}