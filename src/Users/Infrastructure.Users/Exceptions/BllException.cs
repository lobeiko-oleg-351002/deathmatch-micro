﻿namespace Infrastructure.Users.Exceptions;

public class ServiceException : Exception
{
    public ServiceException(string message) : base(message) { }
}
