using System;
using System.Collections.Generic;
using System.Text;

class Guitar : MusicalInstrument
{
    public override string PlaySound()
    {
        return "Гитара играет";
    }
    public override string Tune()
    {
        return "Гитара настраивается";
    }
}