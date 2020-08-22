using Narin.Unity.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleInit : MonoBehaviour {

    private const string METRIX_ID = "yrqtvixaaufpdal";

    void Awake() {

        if(AnalyticsBuilder.CurrentAnalyticsServices == null) {

            AnalyticsBuilder builder = new AnalyticsBuilder();

            builder.SetPublicKey(AnalyticsService.Metrix, METRIX_ID);

            builder.SetRevenueSlug(AnalyticsService.Metrix, "ztcol");
            builder.SetResourceSlug(AnalyticsService.Metrix, SampleUI.CURRENCY_NAME_GEM, "ccqxr");

            builder.BuildAndAttach(this);
        }

        SceneManager.LoadScene(1);
        Destroy(this);
    }
}