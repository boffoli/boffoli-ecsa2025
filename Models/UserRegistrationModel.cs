namespace BlazorBEADs.DemoWasm.Models
{
    /// <summary>
    /// Model for user registration.
    /// </summary>
    public class UserRegistrationModel
    {
        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the country of the user.
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether the user accepts the terms and conditions.
        /// </summary>
        public bool AcceptTerms { get; set; } = false;

        /// <summary>
        /// Gets or sets the gender of the user.
        /// </summary>
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// Validates the user's full name to ensure it meets the minimum length requirement.
        /// </summary>
        /// <returns><see langword="true"/> if the full name is at least 5 characters long; otherwise, <see langword="false"/>.</returns>
        internal bool ValidateFullName()
        {
            return FullName.Length >= 5;
        }
    }
}