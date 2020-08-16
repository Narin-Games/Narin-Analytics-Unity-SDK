namespace Narin.Unity.Analytics {
    public interface IAnalyticsService {
        void Init(string publicKey = null);
        void RevenueEvent(Currency currency, int amount, string itemType, string itemId, string cartType, string slug=null);
    }
}