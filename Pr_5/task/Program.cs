using static System.Console;
class Program {
    static void Main() {
        MusicalInstrument[] instruments = new MusicalInstrument[] {
            new Guitar(), new Piano(), new Drum()
        };
        for (int i = 0; i < instruments.Length; i++) WriteLine(instruments[i].PlaySound());
    }
}