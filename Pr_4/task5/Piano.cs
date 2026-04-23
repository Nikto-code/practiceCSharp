using System;
using System.Collections.Generic;
using System.Text;

class Piano : MusicalInstrument
{
    public override string PlaySound()
    {
        return "Фортепиано играет";
    }

    public override string Tune()
    {
        return "Фортепиано настраивается";
    }
}
