using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (FullNameIncorrect(firstName, lastName))
            {
                return false;
            }

            if (WrongEmailFormat(email))
            {
                return false;
            }

            var age = GetAgeByDate(dateOfBirth);

            if (UnderAge(age))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (IsA_VeryImportantClient(client))
            {
                SetNoCreditLimit(user);
            }
            else if (IsA_ImportantClient(client))
            {
                SetCreditLimitToTimes2(user);
            }
            else
            {
                SetCreditLimit(user);
            }

            if (HasCreditLimitUnder500(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private static int GetAgeByDate(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }

        private static bool HasCreditLimitUnder500(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < 500;
        }

        private static void SetCreditLimit(User user)
        {
            user.HasCreditLimit = true;
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }

        private static void SetCreditLimitToTimes2(User user)
        {
            user.HasCreditLimit = true;
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
        }

        private static void SetNoCreditLimit(User user)
        {
            user.HasCreditLimit = false;
        }

        private static bool IsA_ImportantClient(Client client)
        {
            return client.Type == "ImportantClient";
        }

        private static bool IsA_VeryImportantClient(Client client)
        {
            return client.Type == "VeryImportantClient";
        }

        private static bool UnderAge(int age)
        {
            return age < 21;
        }

        private static bool WrongEmailFormat(string email)
        {
            bool istrue = !email.Contains("@") || !email.Contains(".");
            return istrue;
        }

        private static bool FullNameIncorrect(string firstName, string lastName)
        {
            return string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);
        }
    }
}
