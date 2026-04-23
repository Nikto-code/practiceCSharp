using System;
using System.Collections.Generic;
using System.Text;
abstract class MusicalInstrument
{
    public abstract string PlaySound();
    public virtual string Tune()
    {
        return "Инструмент настраивается";
    }
}