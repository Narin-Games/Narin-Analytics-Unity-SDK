using Narin.Unity.Analytics;
using UnityEngine;
using UnityEngine.Analytics;

public class SampleUI : MonoBehaviour {
    IAnalyticsServices _analyticsServices;
    int _gemNum = 0;

    void Awake() {
        _analyticsServices = AnalyticsBuilder.CurrentAnalyticsServices;
        _gemNum = LoadGemNum();
    }

    void OnDisable() {
        SaveGemNum(_gemNum); 
    }

    public void Init_OnClick() {
        _analyticsServices.Init();
    }

    public void RevenueEventUSD_OnClick() {
        _analyticsServices.RevenueEvent(Currency.USD, 3.2f, "GemPack", "GemPack100", "MainMenuOnClick");
    }

    public void RevenueEventRUB_OnClick() {
        _analyticsServices.RevenueEvent(Currency.RUB, 234, "GemPack", "GemPack100", "MainMenuOnClick");
    }

    public void RevenueEventIRR_OnClick() {
        _analyticsServices.RevenueEvent(Currency.IRR, 800000 , "GemPack", "GemPack100", "MainMenuOnClick");
    }

    public void ResourceSourceEvent_OnClick() {
        _gemNum += 100;
        _analyticsServices.ResourceEvent(ResourceFlowType.Source, "Gem", 100, "LevelFinishReward", "Lvl5", _gemNum);
    }

    public void ResourceSinkEvent_OnClick() {
        _gemNum -= 10;
        _analyticsServices.ResourceEvent(ResourceFlowType.Sink, "Gem", 10, "CharacterSkin", "YellowSkin", _gemNum);
    }

    private int LoadGemNum() {
        return PlayerPrefs.GetInt("GemNum", 0);
    }

    private void SaveGemNum(int gemNum) {
        PlayerPrefs.SetInt("GemNum", gemNum);
    }
}