using Android.Graphics;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using ContainerTransformTicketExample.data;
using ContainerTransformTicketExample.ui.adapters;
using Google.Android.Material.ImageView;
using Fragment = AndroidX.Fragment.App.Fragment;
using Google.Android.Material.Transition.Platform;

namespace ContainerTransformTicketExample.ui.fragments;

public class PodcastFragment : Fragment
{
    private ProgressDialog ProgressDialog { get; set; }
    private ShapeableImageView BannerImageView { get; set; }
    private TextView TitleTextView { get; set; }
    private TextView AuthorTextView { get; set; }
    private RecyclerView EpisodesRecyclerViewView { get; set; }
    private int podcastId { get; set; }
    
    public override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SharedElementEnterTransition = AndroidX.Transitions.TransitionInflater.From(RequireContext()).InflateTransition(
            Android.Resource.Transition.Move
        ).SetDuration(2000);

        // var transition = new MaterialContainerTransform();
        // transition.ScrimColor = Color.Transparent;
        // transition.SetDuration(2000);
        // SharedElementEnterTransition = transition;

        ProgressDialog = new ProgressDialog(Activity);
        ProgressDialog.SetMessage("Loading...");
        ProgressDialog.SetCancelable(true);
        
    }

    public override View? OnCreateView(LayoutInflater inflater, ViewGroup? container, Bundle? savedInstanceState)
    {
        podcastId = Arguments.GetInt("podId");
        return inflater?.Inflate(Resource.Layout.fragment_podcast, container, false);
    }

    public override void OnViewCreated(View view, Bundle? savedInstanceState)
    {
        BannerImageView = view.FindViewById<ShapeableImageView>(Resource.Id.banner_detail_image_view);
        TitleTextView = view.FindViewById<TextView>(Resource.Id.title_detail_text_view);
        AuthorTextView = view.FindViewById<TextView>(Resource.Id.author_detail_text_view);
        EpisodesRecyclerViewView = view.FindViewById<RecyclerView>(Resource.Id.episodes_recycler_view);
        
        EpisodesRecyclerViewView.SetLayoutManager(new LinearLayoutManager(Activity));
        
        GetData();
        
    }

    private async void GetData()
    {
        // ProgressDialog.Show();

        var podcast = PodcastStore.Get(podcastId);
        BannerImageView.SetImageDrawable(Activity.GetDrawable(podcast.Banner));
        // await Task.Delay(4000);
        // ProgressDialog.Dismiss();
        
        if (podcast == null)
            return;

        TitleTextView.Text = podcast.Title;
        AuthorTextView.Text = podcast.Author;
        var adapter = new EpisodeAdapter(podcast.Episodes, podcast.Author);
        
        EpisodesRecyclerViewView.SetAdapter(adapter);
        adapter.NotifyDataSetChanged();
    }
}