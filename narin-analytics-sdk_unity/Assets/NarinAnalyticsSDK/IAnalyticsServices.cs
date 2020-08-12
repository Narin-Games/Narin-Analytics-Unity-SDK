namespace Narin.Unity.Analytics {
    public interface IAnalyticsServices: IAnalyticsService {
        void RegisterService(AnalyticsService service, IAnalyticsService serviceManager, string publicKey);
        IAnalyticsService GetService(AnalyticsService service);
        IAnalyticsServices GetService(params AnalyticsService[] services);
    }
}
