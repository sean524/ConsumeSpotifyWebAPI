
public class GetPlaylistResults
{
    public Playlists playlists { get; set; }
}

public class Playlists
{
    public string href { get; set; }
    public Playlist_Item[] items { get; set; }
    public int limit { get; set; }
    public string next { get; set; }
    public int offset { get; set; }
    public object previous { get; set; }
    public int total { get; set; }
}

public class Playlist_Item
{
    public bool collaborative { get; set; }
    public string description { get; set; }
    public External_Urls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public Image[] images { get; set; }
    public string name { get; set; }
    public Owner owner { get; set; }
    public object primary_color { get; set; }
    public object _public { get; set; }
    public string snapshot_id { get; set; }
    public Tracks tracks { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}

public class Owner
{
    public string display_name { get; set; }
    public External_Urls1 external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}

public class Playlist_Tracks
{
    public string href { get; set; }
    public int total { get; set; }
}

