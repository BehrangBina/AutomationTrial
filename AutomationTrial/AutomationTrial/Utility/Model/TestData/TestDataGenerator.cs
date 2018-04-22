namespace AutomationTrial.Utility.Model.TestData
{
    class TestDataGenerator
    {
        private RandomDataGenerator _randomDataGenerator;
        public Registration GetRegistrationData()
        {
            _randomDataGenerator = new RandomDataGenerator();
            var registration = new Registration();

            registration.FirstName = _randomDataGenerator.GenerateRandomString(6);
            registration.LastName = _randomDataGenerator.GenerateRandomString(6);
            registration.Roles = (int) _randomDataGenerator.RoleGenerator();
            registration.NewsLetter = false;
            registration.Country = "Australia";
            registration.Email = $"{registration.FirstName}.{registration.LastName}@Mailinator.com";
            registration.Username = _randomDataGenerator.GenerateRandomString(8);
            registration.Password = _randomDataGenerator.GenerateRandomString(8);
            registration.ConfirmPassword = registration.Password;
            return registration;
        }

    }
}
