using System;
using System.Collections.Generic;
using System.Text;
using SystemPowiadomien;

namespace SystemPowiadomien
{
    internal class EmailOutput : IOutput
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email Wysyłanie wiadomości: {message}");
        }
    }
}
