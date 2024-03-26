using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace ContainerTransformTicketExample.ui.adapters;

public class EpisodeViewHolder : RecyclerView.ViewHolder
{
    public TextView TitleTextView { get; }
    public TextView AuthorTextView { get; }
    
    public EpisodeViewHolder(View itemView) : base(itemView)
    {
        TitleTextView = itemView.FindViewById<TextView>(Resource.Id.episode_title_text_view);
        AuthorTextView = itemView.FindViewById<TextView>(Resource.Id.episode_author_text_view);
    }

    public void Bind(String title, String author)
    {
        TitleTextView.Text = title;
        AuthorTextView.Text = author;
    }
    
}