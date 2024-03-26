using Android.Views;
using ContainerTransformTransitionAndroid.data;
using Fragment = AndroidX.Fragment.App.Fragment;
using Google.Android.Material.Transition.Platform;

namespace ContainerTransformTransitionAndroid.ui.home.fragments;

public class EmailFragment : Fragment
{
    private long emailId;
    private ImageButton NavigationIcon { get; set; }
    private TextView SubjectTextView { get; set; }
    private TextView SenderTextView { get; set; }
    private TextView RecipientTextView { get; set; }
    private ImageView SenderProfileImageView { get; set; }
    private TextView BodyTextView { get; set; }

    public override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SharedElementEnterTransition = AndroidX.Transitions.TransitionInflater.From(RequireContext()).InflateTransition(
            Android.Resource.Transition.Move
            ).SetDuration(2000);

        // SharedElementEnterTransition = new MaterialContainerTransform().SetDuration(2000);
    }

    public override View OnCreateView(LayoutInflater? inflater, ViewGroup? container, Bundle? savedInstanceState)
    {
        // base.OnCreateView(inflater, container, savedInstanceState);
        emailId = Arguments.GetLong("emailId");
        return inflater?.Inflate(Resource.Layout.fragment_email, container, false);
    }

    public override void OnViewCreated(View view, Bundle? savedInstanceState)
    {
        NavigationIcon = view.FindViewById<ImageButton>(Resource.Id.navigation_icon);
        SubjectTextView = view.FindViewById<TextView>(Resource.Id.subject_text_view);
        SenderTextView = view.FindViewById<TextView>(Resource.Id.sender_text_view);
        RecipientTextView = view.FindViewById<TextView>(Resource.Id.recipient_text_view);
        SenderProfileImageView = view.FindViewById<ImageView>(Resource.Id.sender_profile_image_view);
        BodyTextView = view.FindViewById<TextView>(Resource.Id.body_text_view);
        
        NavigationIcon.Click += (sender, args) =>
        {
            RequireActivity().SupportFragmentManager.PopBackStack();
        };
        
        var email = EmailStore.Get(emailId);
        if (email == null)
        {
            return;
        }

        SubjectTextView.Text = email.Subject;
        SenderTextView.Text = email.SenderPreview;
        RecipientTextView.Text = $"{string.Format(GetString(Resource.String.email_recipient_to), email.RecipientsPreview)}";
        SenderProfileImageView.SetImageDrawable(SenderProfileImageView.Context.GetDrawable(email.Sender.Avatar));
        BodyTextView.Text = email.Body;
    }
}