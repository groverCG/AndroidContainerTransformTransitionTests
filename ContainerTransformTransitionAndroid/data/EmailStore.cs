namespace ContainerTransformTransitionAndroid.data;

public class EmailStore
    {
        private static readonly List<Email> allEmails = new List<Email>
        {
            new Email(
                0L,
                AccountStore.GetContactAccountById(9L),
                new List<Account> { AccountStore.GetDefaultUserAccount() },
                "Package shipped!",
                @"Cucumber Mask Facial has shipped.

                Keep an eye out for a package to arrive between this Thursday and next Tuesday. If for any reason you don't receive your package before the end of next week, please reach out to us for details on your shipment.

                As always, thank you for shopping with us and we hope you love our specially formulated Cucumber Mask!",
                isStarred: true
            ),
            new Email(
                1L,
                AccountStore.GetContactAccountById(6L),
                new List<Account>{ AccountStore.GetDefaultUserAccount() },
                "Brunch this weekend?",
                @"I'll be in your neighborhood doing errands and was hoping to catch you for a coffee this Saturday. If you don't have anything scheduled, it would be great to see you! It feels like it's been forever.

                If we do get a chance to get together, remind me to tell you about Kim. She stopped over at the house to say hey to the kids and told me all about her trip to Mexico.

                Talk to you soon,

                Ali"
            ),
            // Continue adding other emails...
        };


        public static List<Email> GetEmails()
        {
            return allEmails;
        }

        public static Email Get(long id)
        {
            return allEmails.Find(email => email.Id == id);
        }
    }