using Narin.Unity.Analytics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleInit : MonoBehaviour {
    void Awake() {
        AnalyticsBuilder builder = new AnalyticsBuilder();
        builder.SetPublicKey(AnalyticsService.Metrix, "");
        builder.BuildAndAttach(this);
        SceneManager.LoadScene(1);
        Destroy(this);
    }
}