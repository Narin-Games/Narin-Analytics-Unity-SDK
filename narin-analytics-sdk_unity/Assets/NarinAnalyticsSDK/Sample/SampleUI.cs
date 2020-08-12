using Narin.Unity.Analytics;
using UnityEngine;

public class SampleUI : MonoBehaviour {
    IAnalyticsServices _analyticsServices;

    void Awake() {
        _analyticsServices = AnalyticsBuilder.CurrentAnalyticsServices;    
    }

    public void Init_OnClick() {
        _analyticsServices.Init();
    }
}