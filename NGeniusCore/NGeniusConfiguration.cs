
namespace NGeniusCore
{
    public class NGeniusConfiguration
    {
        /// <summary>
        /// Gets or sets the payment integration mode.
        /// </summary>
        public bool IsTest { get; set; }

        /// <summary>
        /// API user name
        /// </summary>
        public string APIKey { get; set; }

        /// <summary>
        /// The outlet id
        /// </summary>
        public string OutletId { get; set; }

        /// <summary>
        /// Indicate whether skip Confirmation Page or not.
        /// </summary>
        public bool SkipConfirmationPage { get; set; }

        /// <summary>
        /// Indicate whether skip 3DS or not.
        /// </summary>
        public bool Skip3DS { get; set; }

        /// <summary>
        /// The RedirectUrl.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// The CancelUrl.
        /// </summary>
        public string CancelUrl { get; set; }
    }
}
