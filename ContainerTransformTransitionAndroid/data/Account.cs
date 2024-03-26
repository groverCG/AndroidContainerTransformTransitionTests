namespace ContainerTransformTransitionAndroid.data;

public class Account
{
    public long Id { get; }
    public long Uid { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string AltEmail { get; }
    public int Avatar { get; }
    public bool IsCurrentAccount { get; set; }

    public string FullName => $"{FirstName} {LastName}";
    public int CheckedIcon => IsCurrentAccount ? Resource.Drawable.ic_done : 0;

    public Account(long id, long uid, string firstName, string lastName, string email, string altEmail, int avatar, bool isCurrentAccount = false)
    {
        Id = id;
        Uid = uid;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        AltEmail = altEmail;
        Avatar = avatar;
        IsCurrentAccount = isCurrentAccount;
    }
}