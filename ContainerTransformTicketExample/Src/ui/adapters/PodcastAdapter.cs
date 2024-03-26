using Android.Views;
using AndroidX.RecyclerView.Widget;
using ContainerTransformTicketExample.data;

namespace ContainerTransformTicketExample.ui.adapters;

public interface IPodcastAdapterListener
{
    void OnPodcastClicked(Podcast podcast, PodcastViewHolder holder);
}

public class PodcastAdapter : RecyclerView.Adapter
{
    public override int ItemCount => Podcasts == null ? 0 : Podcasts.Count;
    private IPodcastAdapterListener Listener { get; }
    private List<Podcast> Podcasts { get; }
    
    public PodcastAdapter(List<Podcast> podcasts, IPodcastAdapterListener listener)
    {
        Podcasts = podcasts;
        Listener = listener;
    }

    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        (holder as PodcastViewHolder).Bind(Podcasts[position]);
    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.podcast_item_layout, parent, false);
        return new PodcastViewHolder(itemView, Listener);
    }
}