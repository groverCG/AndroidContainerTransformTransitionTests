using Android.Views;
using AndroidX.RecyclerView.Widget;
using ContainerTransformTicketExample.data;
using ContainerTransformTicketExample.ui.adapters;
using Fragment = AndroidX.Fragment.App.Fragment;
using Google.Android.Material.Transition.Platform;

namespace ContainerTransformTicketExample.ui.fragments;

public class HomeFragment : Fragment, IPodcastAdapterListener
{
    private RecyclerView PodcastsRecyclerView { get; set; }
    private PodcastAdapter PodcastAdapter { get; set; }

    public override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        EnterTransition = AndroidX.Transitions.TransitionInflater.From(RequireContext()).InflateTransition(
            Android.Resource.Transition.Fade
        ).SetDuration(2000);
    }

    public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
    {
        return inflater?.Inflate(Resource.Layout.fragment_home, container, false);
    }

    public override void OnViewCreated(View view, Bundle? savedInstanceState)
    {
        PodcastsRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recycler_view);
        var podcasts = PodcastStore.GetPodcasts();
        PodcastAdapter = new PodcastAdapter(podcasts, this);
        PodcastsRecyclerView.SetLayoutManager(new GridLayoutManager(Activity, 2));
        // PodcastsRecyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
        PodcastsRecyclerView.SetAdapter(PodcastAdapter);
        
        PostponeEnterTransition();
        ViewTreeObserver observer = view.ViewTreeObserver;
        observer.PreDraw += (sender, args) =>
        {
            StartPostponedEnterTransition();
        };
    }

    public void OnPodcastClicked(Podcast podcast, PodcastViewHolder holder)
    {
        var bundle = new Bundle();
        bundle.PutInt("podId", podcast.Id);
        var transaction = ParentFragmentManager.BeginTransaction();

        var destination = new PodcastFragment();
        destination.Arguments = bundle;

        transaction.AddSharedElement(holder.ContainerMaterialCard, GetString(Resource.String.podcast_card_detail_transition_name));
        transaction.AddSharedElement(holder.BannerImageView, GetString(Resource.String.podcast_image_detail_transiton_name));
        
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