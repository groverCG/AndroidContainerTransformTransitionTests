using AndroidX.RecyclerView.Widget;
using Object = Java.Lang.Object;

namespace ContainerTransformTransitionAndroid.data;

public class Email
{
    public long Id { get; }
    public Account Sender { get; }
    public List<Account> Recipients { get; }
    public string Subject { get; }
    public string Body { get; }
    public bool IsImportant { get; set; }
    public bool IsStarred { get; set; }

    public string SenderPreview => $"{Sender.FullName} - 4 hrs ago";
    public bool HasBody => !string.IsNullOrWhiteSpace(Body);
    public string RecipientsPreview => GetRecipientsPreview();
    public List<Account> NonUserAccountRecipients => GetNonUserAccountRecipients();

    public Email(long id, Account sender, List<Account> recipients = null, string subject = "", string body = "", bool isImportant = false, bool isStarred = false)
    {
        Id = id;
        Sender = sender;
        Recipients = recipients ?? new List<Account>();
        Subject = subject;
        Body = body;
        IsImportant = false;
        IsStarred = false;
    }

    private string GetRecipientsPreview()
    {
        var preview = "";
        foreach (var recipient in Recipients)
        {
            if (!string.IsNullOrEmpty(preview))
                preview += ", ";
            preview += recipient.FirstName;
        }
        return preview;
    }

    private List<Account> GetNonUserAccountRecipients()
    {
        var nonUserAccounts = new List<Account>();
        foreach (var recipient in Recipients)
        {
            if (!AccountStore.IsUserAccount(recipient.Uid))
                nonUserAccounts.Add(recipient);
        }
        return nonUserAccounts;
    }
}