namespace ContainerTransformTicketExample.data;

public class Podcast
{
    public int Id { get; }
    public string Title { get; }
    public string Author { get; }
    public int Banner { get; }
    
    public List<String> Episodes { get; }

    public Podcast(int id, string title, string author, int banner, List<String> episodes)
    {
        Id = id;
        Title = title;
        Author = author;
        Banner = banner;
        Episodes = episodes;
    }
}