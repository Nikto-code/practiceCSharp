class SecuritySystem
{
    public void CheckAccess(object sender, string item)
    {
        LastMessage = $"Security: проверка {item}";
    }
    public string LastMessage { get; private set; }
}
