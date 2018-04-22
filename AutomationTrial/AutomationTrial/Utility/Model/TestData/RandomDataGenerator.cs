using System;
using System.Linq;
using AutomationTrial.Utility.Enums;

namespace AutomationTrial.Utility.Model.TestData
{
    class RandomDataGenerator
    {
        public const string Chars = "abcdefghijklmnopqrstuvwxyz";

        public string GenerateRandomString(int length)
        {
            var random =new Random();
            return new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public RoleEnum RoleGenerator()
        {
            Array values = Enum.GetValues(typeof(RoleEnum));
            Random random = new Random();
            RoleEnum randomBar = (RoleEnum)values.GetValue(random.Next(values.Length));
            return randomBar;
        }
    }
}
