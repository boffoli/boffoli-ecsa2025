namespace BlazorBEADs.DemoWasm.CAiSE2025.Examples.Models
{
    /// <summary>
    /// Model for user registration.
    /// </summary>
    public class UserRegistrationModel
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether the user has accepted the terms and conditions.
        /// </summary>
        public bool AcceptedTerms { get; set; } = false;

        /// <summary>
        /// Gets or sets the country of the user.
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the selected framework preferred by the user.
        /// </summary>
        public string SelectedFramework { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a feedback message for the user.
        /// </summary>
        public string FeedbackMessage { get; set; } = string.Empty;

        /// <summary>
        /// Validates the user's username to ensure it meets the minimum length requirement.
        /// </summary>
        /// <returns><see langword="true"/> if the username is at least 5 characters long; otherwise, <see langword="false"/>.</returns>
        internal bool ValidateUserName()
        {
            return UserName.Length >= 5;
        }
    }
}