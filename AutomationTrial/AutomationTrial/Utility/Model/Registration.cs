namespace AutomationTrial.Utility.Model
{
    /// <summary>
    /// Registration Object representing required properties in registration page item
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// String FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// String LastName
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// String Email
        /// </summary>
        public string Email  { get; set; }
        /// <summary>
        /// String Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// String Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// int Roles
        /// </summary>
        public int Roles { get; set; }
        /// <summary>
        /// bool NewsLetter
        /// </summary>
        public bool NewsLetter { get; set; }
        /// <summary>
        /// String Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// String ConfirmPassword
        /// </summary>
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// String ToString
        /// </summary>
        public override string ToString()
        {
            return $"{nameof(FirstName)}: {FirstName}" +
                   $",{nameof(LastName)}: {LastName}" +
                   $",{nameof(Email)}: {Email}" +
                   $",{nameof(Username)}: {Username}" +
                   $",{nameof(Country)}: {Country}" +
                   $",{nameof(Roles)}: {Roles}" +
                   $",{nameof(NewsLetter)}: {NewsLetter}";
        }
    }
}
