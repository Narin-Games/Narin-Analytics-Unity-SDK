using Narin.Unity.Analytics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleUI : MonoBehaviour {
    AnalyticsManager _analyticsManager;

    void Awake() {
        _analyticsManager = AnalyticsBuilder.CurrentAnalyticsManager;    
    }

    public void Init_OnClick() {
        _analyticsManager.Init();
    }
}