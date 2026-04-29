class User : ISubscriber
{
    public string Name { get; set; }
    public ICollection<string> Notifications { get; } = new List<string>();
    public User(string name)
    {
        Name = name;
    }
    public void Update(string channelName, string videoTitle)
    {
        Notifications.Add($"{Name} получил видео '{videoTitle}' от {channelName}");
    }
}