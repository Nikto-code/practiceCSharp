using System;
using System.Collections.Generic;
using System.Text;

class CollectionException : Exception {
    public CollectionException() { }
    public CollectionException(string message) : base(message) { }
    public CollectionException(string message, Exception inner) : base(message, inner) { }
}