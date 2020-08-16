using Narin.Unity.Analytics;
using UnityEngine;

public class SampleUI : MonoBehaviour {

    private const string SLUG_METRIX_ON_PURCHASED = "ztcol";
    IAnalyticsServices _analyticsServices;

    void Awake() {
        _analyticsServices = AnalyticsBuilder.CurrentAnalyticsServices;    
    }

    public void Init_OnClick() {
        _analyticsServices.Init();
    }

    public void RevenueEvent_OnClick() {
        _analyticsServices.RevenueEvent(Currency.IRR, 32000, "GemPack", "GemPack100", "MainMenuOnClick", SLUG_METRIX_ON_PURCHASED);
    }

}