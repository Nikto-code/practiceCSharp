using static System.Console;
class Program {
    static void Main() {
        BinaryConverter bin = new BinaryConverter();
        HexConverter hex = new HexConverter();
        NumberConverter converter;
        converter = bin.Convert;
        WriteLine("Binary: " + converter(25));
        converter = hex.Convert;
        WriteLine("Hex: " + converter(25));
    }
}