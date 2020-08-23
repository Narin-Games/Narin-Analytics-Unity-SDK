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
            
            //Some analytics services using slugs for each event that you sent
            //This line define slug for revenue event in Metrix service
            builder.SetRevenueSlug(AnalyticsService.Metrix, "ztcol");
            
            // Finally you must build the IAnalyticsServices and 
            // Attached them to the gameObject that you passed reference as a parameter
            builder.BuildAndAttach(this);
        }

        SceneManager.LoadScene(1);
        Destroy(this);
    }
}
```
**Notice 1-1:**

The Build stage only needs to happen once when the game is run and after calling **AnalyticsBuilder.BuildAndAttach()**, you create a IAnalyticsServices component whose reference is stored in the static variable **AnalyticsBuilder.CurrentAnalyticsServices** and all the information entered about the store is reset in the IAPBuilder object.

``` csharp
//This static variable is set after calling IAPBuilder.BuildAndAttach()
AnalyticsBuilder.CurrentAnalyticsServices
```
**Notice 1-2:**

It is better to perform this step in a separate Scene that is loaded only once in the game.

### 2) Initialize:
Before using any of the **IAnalyticsServices** object methods, We must first initialize the all analytics services via the **IAnalyticsServices.Init()** method. after initializing analytics services you can get basic metrics (such as retuntion or session length) in any analytics you initialized.

```csharp
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
```
### 3) Use Analytics Methods:

### 3-1) Send events through one or more specific services:
In this SDK you will be able to send an event through one or more specific services, such as the following code:
```csharp
// Get all available analytics services
var analyticsServices          = AnalyticsBuilder.CurrentAnalyticsServices;

// Get one or more specific services such as Firebase Analytics, GameAnalytics or ...
var specificAnalyticServices   = AnalyticsBuilder.CurrentAnalyticsServices.GetService(AnalyticsService.FirebaseAnalytics, AnalyticsService.GameAnalytics);

```

### 3-2) Revenue Event:
This event is designed to record monetary income from in-app purchases.

``` csharp
public void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType, string slug=null);
```
**Parameters:**

|Parameter          | Used in Services  | Description |
|:--                |:--:               |:--|
|Currency currency  |GA, FA, M          |Currency code (e.g Currency.USD)                                               |
|float amount       |GA, FA, M          |Payment Amount (e.g 3.2 is 3.2$)                                               |
|string itemType    |GA                 |Type of package that paid for (e.g "GoldPack")                                 |
|string itemId      |GA                 |Id of package that paid for (e.g "GoldPack100")                                |
|string cartType    |GA                 |How and Where buy a package (e.g "EndOfLvl")                                   |
|string slug        |M                  |Id that used for sending event to Metrix Service (You must get it from panel)  |

**Restrictions:**
|GameAnalytics                      |Firebase                           |Metrix |
|:--:                               |:--:                               |:--:   |
|Can't record Rial (IRR) payments   |Can't record Rial (IRR) payments   |Only can record Dollar, Euro and Rial payments |
|                                   |Can't record package that paid for |Can't record package that paid for             |

### 3-3) Resource Event:

**Sample Code:**
```csharp
var analyticsServices = AnalyticsBuilder.CurrentAnalyticsServices;
analyticsServices.RevenueEvent(Currency.USD, 3.2f, "GemPack", "GemPack100", "MainMenuOnClick", "MetrixSlug");
```
## Sample
In the [Sample Directory](https://github.com/Narin-Games/Narin-Analytics-Unity-SDK/tree/master/narin-analytics-sdk_unity/Assets/NarinAnalyticsSDK/Sample) there is a complete example of how to use the SDK that you can use.

## Build and Export Project

You need to do the following two steps before export from your project:

### 1) Set Scripting Define Symbols:
First, go to the following path in the Unity engine:

**File > Build Settings > Player Settings > Player > Other Settings > Scripting Define Symbols**

![unity-scripting-define-symbols]()

Then in this path, define the specific symbol of that store according to the table:

| Analytics Service     | Symbole           |
| :--:                  | :--:              |
| Metrix                | \_metrix_         |
| GameAnalytics         | \_gameanalytics_  |
| Firebase Ananlytics   | \_fireanalytics_  |


This step causes only the code related to your release to be used in your final build.

