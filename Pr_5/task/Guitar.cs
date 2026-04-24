class Guitar : MusicalInstrument {
    public Guitar() : base("Гитара") { }
    public override string PlaySound() {
        return $"{Name} Играет";
    }
}