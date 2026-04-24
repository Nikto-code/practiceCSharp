class Drum : MusicalInstrument {
    public Drum() : base("Барабан") { }
    public override string PlaySound() {
        return $"{Name} Играет";
    }
}