using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGeniusCore
{
    public class NGeniusConstants
    {
        public const string NGeniusReferenceNumber = "NGeniusReferenceNumber";
        
        public const string ApiIdentityAcceptJson = "application/vnd.ni-identity.v1+json";
        public const string ApiPaymentAcceptJson = "application/vnd.ni-payment.v2+json";
        public const string ApiQueryStringRef = "ref";
        public const int CurrencyMultiplicationFactor = 100;


        public class ApiUrl
        {
            public const string OrderStatus = "transactions/outlets/{0}/orders/{1}";
            public const string AccessToken = "identity/auth/access-token";
            public const string CreateOrder = "transactions/outlets/{0}/orders";
        }

        public class ApiResponseState
        {
            public const string CAPTURED = "CAPTURED";
        }

        public class ApiOrderType
        {
            public const string SALE = "SALE";
        }

        public class ApiLanguageCode
        {
            public const string EN = "en";
            public const string FR = "fr";
            public const string AR = "ar";
        }

        public class ApiauthorizationMode
        {
            public const string Bearer = "Bearer {0}";
            public const string Basic = "Basic {0}";
        }
    }
}
