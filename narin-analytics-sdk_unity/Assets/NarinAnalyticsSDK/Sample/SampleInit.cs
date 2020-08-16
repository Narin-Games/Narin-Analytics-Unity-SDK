using Narin.Unity.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleInit : MonoBehaviour {

    public const string METRIX_ID = "yrqtvixaaufpdal";

    void Awake() {

        if(AnalyticsBuilder.CurrentAnalyticsServices == null) {

            AnalyticsBuilder builder = new AnalyticsBuilder();

            builder.SetPublicKey(AnalyticsService.Metrix, METRIX_ID);

            builder.BuildAndAttach(this);
        }

        SceneManager.LoadScene(1);
        Destroy(this);
    }
}