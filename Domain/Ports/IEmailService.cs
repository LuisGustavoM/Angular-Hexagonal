﻿namespace Domain.Ports
{
    public interface IEmailService
    {
        void SendEmail(string from, string to, string subject, string body);
    }
}
