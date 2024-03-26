using Android.Content.Res;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using ContainerTransformTransitionAndroid.data;
using Google.Android.Material.Card;

namespace ContainerTransformTransitionAndroid.ui.home.adapters;

public class EmailViewHolder : RecyclerView.ViewHolder
{
    public MaterialCardView CardView { get; set; }
    private TextView SenderTextView { get; set; }
    private TextView SubjectTextView { get; set; }
    private TextView BodyPreviewTextView { get; set; }
    public ImageView SenderProfileImageView { get; set; }
    
    private IEmailAdapterListener Listener { get; set; }
    
    public EmailViewHolder(View itemView, IEmailAdapterListener listener) : base(itemView)
    {
        Listener = listener;
        CardView = itemView.FindViewById<MaterialCardView>(Resource.Id.card_view);
        SenderTextView = itemView.FindViewById<TextView>(Resource.Id.sender_text_view);
        SubjectTextView = itemView.FindViewById<TextView>(Resource.Id.subject_text_view);
        BodyPreviewTextView = itemView.FindViewById<TextView>(Resource.Id.body_preview_text_view);
        SenderProfileImageView = itemView.FindViewById<ImageView>(Resource.Id.sender_profile_image_view);
    }

    public void Bind(Email email)
    {
        SenderTextView.Text = email.SenderPreview;
        SubjectTextView.Text = email.Subject;
        BodyPreviewTextView.Text = email.Body;
        BodyPreviewTextView.Visibility = email.HasBody ? ViewStates.Visible : ViewStates.Gone;
        SenderProfileImageView.SetImageDrawable(SenderProfileImageView.Context.GetDrawable(email.Sender.Avatar));

        CardView.TransitionName = $"{Resource.String.email_card_detail_transition_name}{email.Subject}";
        
        SenderProfileImageView.TransitionName =
            $"{Resource.String.email_card_detail_transition_name}{email.Sender.Avatar}";
        
        int textAppearance;
        if (email.IsImportant)
        {
            textAppearance = Resource.Attribute.textAppearanceHeadline4;
        } else
        {
            textAppearance = Resource.Attribute.textAppearanceHeadline5;
        }

        SubjectTextView.SetTextAppearance(
            SubjectTextView.Context,
            textAppearance
        );

        CardView.Click += (sender, args) =>
        {
            Listener.OnEmailClicked(email, this);
        };
    }
}