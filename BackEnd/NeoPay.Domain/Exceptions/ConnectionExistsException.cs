namespace NeoPay.Domain.Exceptions;

public class ConnectionExistsException(string message) : Exception(message);