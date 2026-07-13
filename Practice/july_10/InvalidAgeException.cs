using System;

// custom exception class - inherits from the built-in Exception class
// used to represent a specific error: an invalid age value
public class InvalidAgeException : Exception
{
    // constructor that takes a custom error message
    // ": base(message)" passes the message up to the parent Exception class
    // so it gets stored in the built-in ex.Message property
    public InvalidAgeException(string message) : base(message) { }
}