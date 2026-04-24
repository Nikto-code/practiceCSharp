class Piano : MusicalInstrument {
    public Piano() : base("Фортепиано") { }
    public override string PlaySound() {
        return $"{Name} Играет";
    }
}