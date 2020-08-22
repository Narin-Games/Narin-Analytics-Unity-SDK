using Narin.Unity.Analytics;
using UnityEngine;
using UnityEngine.UI;

public class SampleUI : MonoBehaviour {

    public const string CURRENCY_NAME_GEM = "Gem";
    public const string PREFKEY_CURRENCY_NUM = "GemNum";

    [SerializeField] Text _txtLog;

    private IAnalyticsServices _analyticsServices;
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
        _txtLog.text = "Init all analytics services";
    }

    public void RevenueEventUSD_OnClick() {
        _analyticsServices.RevenueEvent(Currency.USD, 3.2f, "GemPack", "GemPack100", "MainMenuOnClick");
        _txtLog.text = "Log revenue event: 3.2 USD for 'GemPack100'";
    }

    public void RevenueEventRUB_OnClick() {
        _analyticsServices.RevenueEvent(Currency.RUB, 234, "GemPack", "GemPack100", "MainMenuOnClick");
        _txtLog.text = "Log revenue event: 234 RUB for 'GemPack100'";
    }

    public void RevenueEventIRR_OnClick() {
        _analyticsServices.RevenueEvent(Currency.IRR, 800000 , "GemPack", "GemPack100", "MainMenuOnClick");
        _txtLog.text = "Log revenue event: 800,000 IRR for 'GemPack100'";
    }

    public void ResourceSourceEvent_OnClick() {
        _gemNum += 100;
        _analyticsServices.ResourceEvent(ResourceFlowType.Source, CURRENCY_NAME_GEM, 100, "LevelFinishReward", "LevelFinishRewardLvl5", _gemNum);
        _txtLog.text = "Log resource source event: 100 Gem Added in LevelFinishReward in Lvl5";
    }

    public void ResourceSinkEvent_OnClick() {
        _gemNum -= 10;
        _analyticsServices.ResourceEvent(ResourceFlowType.Sink, CURRENCY_NAME_GEM, 10, "CharacterSkin", "YellowSkin", _gemNum);
        _txtLog.text = "Log resource sink event: 10 Gem Subtract for buying CharacterSkin.CharacterYellowSkin";
    }

    private int LoadGemNum() {
        return PlayerPrefs.GetInt(PREFKEY_CURRENCY_NUM, 0);
    }

    private void SaveGemNum(int gemNum) {
        PlayerPrefs.SetInt(PREFKEY_CURRENCY_NUM, gemNum);
    }
}