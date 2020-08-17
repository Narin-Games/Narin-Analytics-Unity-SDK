#if _dev_ || _fireanalytics_

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Analytics;
using Unity.Collections.LowLevel.Unsafe;
using System;

namespace Narin.Unity.Analytics {
    public partial class AnalyticsBuilder {

        private class FirebaseAnalyticsService : SingletonMono<FirebaseAnalyticsService>, IAnalyticsService {
            public void Init(string publicKey = null) {
                Debug.Log("Firebase Analytics Initialized");
            }

            public void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType, string slug = null) {
                
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
        }
    }
}

#endif