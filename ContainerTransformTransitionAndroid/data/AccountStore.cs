using AndroidX.Lifecycle;

namespace ContainerTransformTransitionAndroid.data;

public static class AccountStore
    {
        private static readonly List<Account> allUserAccounts = new List<Account>
        {
            new Account(1L, 0L, "Jeff", "Hansen", "hikingfan@gmail.com", "hkngfan@outside.com", Resource.Drawable.avatar_10, true),
            new Account(2L, 0L, "Jeff", "H", "jeffersonloveshiking@gmail.com", "jeffersonloveshiking@work.com", Resource.Drawable.avatar_2),
            new Account(3L, 0L, "Jeff", "Hansen", "jeffersonc@google.com", "jeffersonc@gmail.com", Resource.Drawable.avatar_9)
        };

        private static readonly List<Account> allUserContactAccounts = new List<Account>
        {
            new Account(4L, 1L, "Tracy", "Alvarez", "tracealvie@gmail.com", "tracealvie@gravity.com", Resource.Drawable.avatar_1),
            new Account(5L, 2L, "Allison", "Trabucco", "atrabucco222@gmail.com", "atrabucco222@work.com", Resource.Drawable.avatar_3),
            new Account(6L, 3L, "Ali", "Connors", "aliconnors@gmail.com", "aliconnors@android.com", Resource.Drawable.avatar_5),
            new Account(7L, 4L, "Alberto", "Williams", "albertowilliams124@gmail.com", "albertowilliams124@chromeos.com", Resource.Drawable.avatar_0),
            new Account(8L, 5L, "Kim", "Alen", "alen13@gmail.com", "alen13@mountainview.gov", Resource.Drawable.avatar_7),
            new Account(9L, 6L, "Google", "Express", "express@google.com", "express@gmail.com", Resource.Drawable.avatar_express),
            new Account(10L, 7L, "Sandra", "Adams", "sandraadams@gmail.com", "sandraadams@textera.com", Resource.Drawable.avatar_2),
            new Account(11L, 8L, "Trevor", "Hansen", "trevorhandsen@gmail.com", "trevorhandsen@express.com", Resource.Drawable.avatar_8),
            new Account(12L, 9L, "Sean", "Holt", "sholt@gmail.com", "sholt@art.com", Resource.Drawable.avatar_6),
            new Account(13L, 10L, "Frank", "Hawkins", "fhawkank@gmail.com", "fhawkank@thisisme.com", Resource.Drawable.avatar_4)
        };

        public static Account GetDefaultUserAccount() => allUserAccounts.First();

        public static List<Account> GetAllUserAccounts() => allUserAccounts;

        public static bool IsUserAccount(long uid) => allUserAccounts.Any(account => account.Uid == uid);

        public static Account GetContactAccountById(long accountId)
        {
            return allUserContactAccounts.FirstOrDefault(account => account.Id == accountId) ?? allUserContactAccounts.First();
        }
    }