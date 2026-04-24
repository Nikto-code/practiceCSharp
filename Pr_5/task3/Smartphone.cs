class Smartphone : SmartDevice, ICanPlayMusic, ICanMakeCalls
{
    public Smartphone(string name) : base(name) { }

    public string PlayMusic()
    {
        return $"{Name} воспроизводит музыку";
    }

    public string MakeCall(string number)
    {
        return $"{Name} звонит на {number}";
    }
}