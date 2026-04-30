using System;
using System.Collections.Generic;
using System.Text;

class ActivateAlarmCommand : ICommand
{
    private AlarmSystem _alarm;

    public ActivateAlarmCommand(AlarmSystem alarm)
    {
        _alarm = alarm;
    }

    public void Execute()
    {
        _alarm.Activate();
    }
}

class DeactivateAlarmCommand : ICommand
{
    private AlarmSystem _alarm;

    public DeactivateAlarmCommand(AlarmSystem alarm)
    {
        _alarm = alarm;
    }

    public void Execute()
    {
        _alarm.Deactivate();
    }
}