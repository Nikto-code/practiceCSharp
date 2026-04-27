using System;
using System.Collections.Generic;
using System.Text;

class OutOfStockException : Exception{
    public OutOfStockException() : base("Товар отсутствует на складе") { }
    public OutOfStockException(string message) : base(message) { }
    public OutOfStockException(string message, Exception inner) : base(message, inner) { }
}