class SmartSpeaker : SmartDevice, ICanPlayMusic
{
    public SmartSpeaker(string name) : base(name) { }

    public string PlayMusic()
    {
        return $"{Name} воспроизводит музыку";
    }
}
