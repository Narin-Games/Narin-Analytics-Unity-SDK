# Narin-Analytics-Unity-SDK
When using different Analytics services, it happens that to validate the data of one analytics service, you implement another service next to it to compare the data to make sure the data is correct.

It also happens that from a service that gives you special features such as Mobile Attribution along with another service that gives you special features for checking certain metrics in F2P games.

Or when one of the data analysis services has a problem, you replace it with another service.

All of the above will involve changes to your code because the integration of each of these data analysis services is different, and ultimately causes the Open/Close principle to be disregarded in your codes.

This SDK by designing a general interface for all data analysis services in an attempt to solve these problems in using different data analysis services.

The advantages of this service for you include the following:

1) Designing an interface for the entire data analysis service so that the maximum possibilities of these services are covered and at the same time everyone follows a single interface
2) Minimize code changes when replacing or using multiple services at the same time
3) Integrate multiple data analysis services with just one implementation
4) Can be used in Distributed Build System to use different data analysis services for different releases

## How To Use
This system has three stages in its life cycle, which I will explain in order:

**BUILD --> Initialize --> Use IAP Methods**

### 1) Build:
In this step you need to create an object of type IAnalyticsServices through the AnalyticsBuilder class To access the analytics service API through this object.

You must first provide analytics services information to the AnalyticsBuilder class, as in the following code example:

```csharp
using Narin.Unity.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleInit : MonoBehaviour {

    public const string METRIX_ID = "MetrixId";

    void Awake() {
    
        // Check if IAnalyticsServices object is not build yet
        if(AnalyticsBuilder.CurrentAnalyticsServices == null) {
            
            // Create a new builder object
            AnalyticsBuilder builder = new AnalyticsBuilder();

            // Set ID for each analytics services (Only Metrix need to pass ID in code)
            builder.SetPublicKey(AnalyticsService.Metrix, METRIX_ID);

            // Finally you must build the IAnalyticsServices and 
            // Attached them to the gameObject that you passed reference as a parameter
            builder.BuildAndAttach(this);
        }

        SceneManager.LoadScene(1);
        Destroy(this);
    }
}
```
