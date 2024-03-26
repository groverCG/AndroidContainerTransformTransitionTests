using Android.Views;
using AndroidX.RecyclerView.Widget;
using ContainerTransformTransitionAndroid.data;
using ContainerTransformTransitionAndroid.ui.home.adapters;
using Google.Android.Material.Transition;
using Fragment = AndroidX.Fragment.App.Fragment;
using FragmentTransaction = AndroidX.Fragment.App.FragmentTransaction;

namespace ContainerTransformTransitionAndroid.ui.home.fragments;

public class HomeFragment : Fragment, IEmailAdapterListener
{
    private EmailAdapter EmailAdapter;
    private RecyclerView EmailsRecyclerView;

    public override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        var transition = new MaterialFadeThrough();
        transition.SetDuration(2000);
        EnterTransition = transition;
    }

    public override View OnCreateView(LayoutInflater? inflater, ViewGroup? container, Bundle? savedInstanceState)
    {
        // base.OnCreateView(inflater, container, savedInstanceState);
        return inflater?.Inflate(Resource.Layout.fragment_home, container, false);
    }

    public override void OnViewCreated(View view, Bundle? savedInstanceState)
    {
        EmailsRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recycler_view);
        var emails = EmailStore.GetEmails();
        EmailAdapter = new EmailAdapter(emails, this);
        EmailsRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
        EmailsRecyclerView.SetAdapter(EmailAdapter);
        EmailAdapter.NotifyDataSetChanged();
        
        PostponeEnterTransition();
        ViewTreeObserver observer = view.ViewTreeObserver;
        observer.PreDraw += (sender, args) =>
        {
            StartPostponedEnterTransition();
        };
    }

    public void OnEmailClicked(Email email, EmailViewHolder holder)
    {
        var bundle = new Bundle();
        bundle.PutLong("emailId", email.Id);
        FragmentTransaction transaction = ParentFragmentManager.BeginTransaction();

        var destination = new EmailFragment();
        destination.Arguments = bundle;

        var emailCardDetailTransitionName = GetString(Resource.String.email_card_detail_transition_name);
        
        transaction.AddSharedElement(holder.CardView, emailCardDetailTransitionName);
        transaction.AddSharedElement(holder.SenderProfileImageView,
            GetString(Resource.String.email_image_transition_name));
        

        transaction.Replace(Resource.Id.app_nav_host_fragment, destination);
        transaction.AddToBackStack(destination.GetType().Name);
        ExitTransition = AndroidX.Transitions.TransitionInflater.From(RequireContext()).InflateTransition(
            Android.Resource.Transition.Fade
        ).SetDuration(2000);
        ReenterTransition = AndroidX.Transitions.TransitionInflater.From(RequireContext()).InflateTransition(
            Android.Resource.Transition.Fade
        ).SetDuration(2000);
        transaction.Commit();
    }
}