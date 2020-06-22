using System;
using WebApiClient;
using Import.Utility;
using System.Threading;


namespace Import.Factory
{
    internal static class ApiClientFactory
    {
        private static Uri apiBaseUri;

        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(
          () => new ApiClient(apiBaseUri),
          LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
            apiBaseUri = new Uri(AppSettings.WebApiBaseUrl);
        }

        public static ApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }

}
