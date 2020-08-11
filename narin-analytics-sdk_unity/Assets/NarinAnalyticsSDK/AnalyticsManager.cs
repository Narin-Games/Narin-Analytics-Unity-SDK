using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narin.Unity.Analytics {
    public class AnalyticsManager: MonoBehaviour {

        private Dictionary<AnalyticsService, IAnalyticsService> _services = new Dictionary<AnalyticsService, IAnalyticsService>();
        private Dictionary<AnalyticsService, string> _publicKeys = new Dictionary<AnalyticsService, string>();

        public void RegisterService(AnalyticsService service, IAnalyticsService serviceManager, string publicKey = null) {
            _services.Add(service, serviceManager);
            _publicKeys.Add(service, publicKey);
        }

        public void Init() {
            foreach(var service in _services.Keys) {
                _services[service].Init(_publicKeys[service]);
            }
        }
    }
}