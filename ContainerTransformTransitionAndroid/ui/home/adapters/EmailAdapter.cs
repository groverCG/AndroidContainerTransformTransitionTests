using Android.Views;
using AndroidX.RecyclerView.Widget;
using ContainerTransformTransitionAndroid.data;

namespace ContainerTransformTransitionAndroid.ui.home.adapters;

public interface IEmailAdapterListener
{
    void OnEmailClicked(Email email, EmailViewHolder holder);
}

public class EmailAdapter : RecyclerView.Adapter
{
    public override int ItemCount => Emails == null ? 0 : Emails.Count; 
    private IEmailAdapterListener Listener { get; set; }
    private List<Email> Emails { get; set; }

    public EmailAdapter(List<Email> emails, IEmailAdapterListener listener)
    {
        Emails = emails;
        Listener = listener;
    }

    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        (holder as EmailViewHolder).Bind(Emails[position]);
    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.email_item_layout, parent, false);
        return new EmailViewHolder(itemView, Listener);
    }
}