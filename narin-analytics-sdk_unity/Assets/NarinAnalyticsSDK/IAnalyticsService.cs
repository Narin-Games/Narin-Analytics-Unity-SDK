namespace Narin.Unity.Analytics {
    public interface IAnalyticsService {
        void Init();
        void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType);
        void ResourceEvent(ResourceFlowType flowType, string virtualCurrency, float amount, string itemType, string itemId, float wholeAmount = -1);
    }
}