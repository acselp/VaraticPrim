namespace VaraticPrim.Domain.Exceptions;

public class WrongPasswordOrEmailException(string message) : Exception(message);