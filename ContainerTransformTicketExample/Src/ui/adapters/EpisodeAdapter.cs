using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace ContainerTransformTicketExample.ui.adapters;

public class EpisodeAdapter : RecyclerView.Adapter
{
    public override int ItemCount => Episodes == null ? 0 : Episodes.Count;
    private List<String> Episodes { get; }
    
    private String Author { get; }

    public EpisodeAdapter(List<String> episodes, String author)
    {
        Episodes = episodes;
        Author = author;
    }

    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        (holder as EpisodeViewHolder).Bind(Episodes[position], Author);
    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.episode_item_layout, parent, false);
        return new EpisodeViewHolder(itemView);
    }
}