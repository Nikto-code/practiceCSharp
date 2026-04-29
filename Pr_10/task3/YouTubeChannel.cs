class YouTubeChannel
{
    private ICollection<ISubscriber> _subscribers = new List<ISubscriber>();
    private string _name;

    public YouTubeChannel(string name)
    {
        _name = name;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void UploadVideo(string videoTitle)
    {
        Notify(videoTitle);
    }

    private void Notify(string videoTitle)
    {
        foreach (var sub in _subscribers)
        {
            sub.Update(_name, videoTitle);
        }
    }
}