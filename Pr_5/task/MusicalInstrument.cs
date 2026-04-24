using System;
using System.Collections.Generic;
using System.Text;

abstract class MusicalInstrument {
    public string Name { get; set; }
    protected MusicalInstrument(string name) {
        Name = name;
    }
    public abstract string PlaySound();
}
