namespace Narin.Unity.Analytics {
    public interface IAnalyticsService {
        void Init(string publicKey = null);
        void RevenueEvent(Currency currency, float amount, string itemType, string itemId, string cartType, string slug=null);
    }
}