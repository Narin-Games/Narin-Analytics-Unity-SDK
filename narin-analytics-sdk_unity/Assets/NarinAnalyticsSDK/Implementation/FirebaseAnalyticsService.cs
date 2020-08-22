#if _dev_ || _fireanalytics_

using System.Collections;
using UnityEngine;
using Firebase.Analytics;

namespace Narin.Unity.Analytics {
    public partial class AnalyticsBuilder {

        private class FirebaseAnalyticsService : SingletonMono<FirebaseAnalyticsService>, IAnalyticsService {
            public void Init() {
                Debug.Log("Firebase Analytics Initialized");
            }

            public void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType) {
                
                FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPurchase, 
                     new Parameter(FirebaseAnalytics.ParameterCurrency      , currency.CurrencyCode)
                    ,new Parameter(FirebaseAnalytics.ParameterValue         , amount)
                    //,new Parameter(FirebaseAnalytics.ParameterItems         , itemType + '.' + itemId)
                    //,new Parameter(FirebaseAnalytics.ParameterAffiliation   , "Store Name")
                    //,new Parameter(FirebaseAnalytics.ParameterTransactionId , "TransactionId")
                    //,new Parameter(FirebaseAnalytics.ParameterTax           , 5.6)
                    );
                Debug.Log("Firebase Analytics Sent Business Event");
            }

            public void ResourceEvent(ResourceFlowType flowType, string virtualCurrency, float amount, string itemType, string itemId, float wholeAmount = -1) {
                var pVCurrency  = new Parameter(FirebaseAnalytics.ParameterVirtualCurrencyName, virtualCurrency);
                var pValue      = new Parameter(FirebaseAnalytics.ParameterValue, amount);
                var pItem       = new Parameter(FirebaseAnalytics.ParameterItemId, itemType +'.'+itemId);
                
                if(flowType == ResourceFlowType.Source) {
                    FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventEarnVirtualCurrency, pVCurrency, pValue);
                    Debug.Log("Firebase Analytics Sent Resource Source Event");
                }

                else

                if(flowType == ResourceFlowType.Sink) {
                    FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventSpendVirtualCurrency, pItem, pVCurrency, pValue);
                    Debug.Log("Firebase Analytics Sent Resource Sink Event");
                }
            }
        }

    }
}

#endif