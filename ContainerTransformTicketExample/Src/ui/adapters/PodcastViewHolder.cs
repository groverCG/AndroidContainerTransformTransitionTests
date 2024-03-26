using Android.Views;
using AndroidX.Core.View;
using AndroidX.RecyclerView.Widget;
using ContainerTransformTicketExample.data;
using Google.Android.Material.Card;
using Google.Android.Material.ImageView;

namespace ContainerTransformTicketExample.ui.adapters;

public class PodcastViewHolder : RecyclerView.ViewHolder
{
    public MaterialCardView ContainerMaterialCard { get; }
    public ShapeableImageView BannerImageView { get; }
    public TextView TitleTextView { get; }
    public TextView AuthorTextView { get; }

    private IPodcastAdapterListener Listener { get; set; }
    
    public PodcastViewHolder(View itemView, IPodcastAdapterListener listener) : base(itemView)
    {
        Listener = listener;
        ContainerMaterialCard = itemView.FindViewById<MaterialCardView>(Resource.Id.container_material_card);
        BannerImageView = itemView.FindViewById<ShapeableImageView>(Resource.Id.banner_image_view);
        TitleTextView = itemView.FindViewById<TextView>(Resource.Id.title_text_view);
        AuthorTextView = itemView.FindViewById<TextView>(Resource.Id.author_text_view);
    }

    public void Bind(Podcast podcast)
    {
        TitleTextView.Text = podcast.Title;
        AuthorTextView.Text = podcast.Author;
        BannerImageView.SetImageDrawable(BannerImageView.Context.GetDrawable(podcast.Banner));

        ContainerMaterialCard.TransitionName = $"{ContainerMaterialCard.Context.GetString(Resource.String.podcast_card_detail_transition_name)}_{podcast.Id}";
        BannerImageView.TransitionName = $"{ContainerMaterialCard.Context.GetString(Resource.String.podcast_image_detail_transiton_name)}_{podcast.Id}";

        ContainerMaterialCard.Click += (sender, args) =>
        {
            Listener.OnPodcastClicked(podcast, this);
        };
    }
}