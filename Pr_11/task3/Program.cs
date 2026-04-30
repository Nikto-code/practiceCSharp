using static System.Console;

class Program
{
    static void Main()
    {
        AlarmSystem alarm = new AlarmSystem();

        ICommand activate = new ActivateAlarmCommand(alarm);
        ICommand deactivate = new DeactivateAlarmCommand(alarm);

        SecurityPanel panel = new SecurityPanel();

        panel.SetCommand(activate);
        panel.PressButton();

        panel.SetCommand(deactivate);
        panel.PressButton();
    }
}