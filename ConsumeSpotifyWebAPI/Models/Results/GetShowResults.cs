﻿public class GetShowResults
{
    public Shows shows { get; set; }
}

public class Shows
{
    public string href { get; set; }
    public Show_Item[] items { get; set; }
    public int limit { get; set; }
    public string next { get; set; }
    public int offset { get; set; }
    public object previous { get; set; }
    public int total { get; set; }
}

public class Show_Item
{
    public string[] available_markets { get; set; }
    public object[] copyrights { get; set; }
    public string description { get; set; }
    public bool _explicit { get; set; }
    public External_Urls external_urls { get; set; }
    public string href { get; set; }
    public string html_description { get; set; }
    public string id { get; set; }
    public Image[] images { get; set; }
    public bool is_externally_hosted { get; set; }
    public string[] languages { get; set; }
    public string media_type { get; set; }
    public string name { get; set; }
    public string publisher { get; set; }
    public int total_episodes { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}
