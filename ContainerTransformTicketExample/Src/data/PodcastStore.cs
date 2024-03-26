namespace ContainerTransformTicketExample.data;

public static class PodcastStore
{
    private static List<String> episodes = new List<string>()
    {
        "Quidem molestiae enim",
        "Sunt qui excepturi placeat culpa",
        "Omnis laborum odio",
        "Non esse culpa molestiae omnis sed optio",
        "Eaque aut omnis a",
        "Natus impedit quibusdam illo est"
    };
    
    private static readonly List<Podcast> allPodcasts = new List<Podcast>
    {
        new Podcast(
            222,
            "Play it as it Lays",
            "Trilogy",
            Resource.Drawable.avatar_2,
            episodes
        ),
        new Podcast(
            333,
            "Concrete Poetry",
            "Lonely Hunter",
            Resource.Drawable.avatar_10,
            episodes
        ),
        new Podcast(
            444,
            "Intuition Cities",
            "Me & Others",
            Resource.Drawable.avatar_7,
            episodes
        ),
        
        new Podcast(
            111,
            "21s Strangers",
            "For Now",
            Resource.Drawable.avatar_9,
            episodes
        ),
    };
    
    public static Podcast Get(int id)
    {
        return allPodcasts.Find(podcast => podcast.Id == id);
    }
    
    public static List<Podcast> GetPodcasts() => allPodcasts;
}