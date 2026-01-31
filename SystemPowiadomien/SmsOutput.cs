using System;
using System.Collections.Generic;
using System.Text;
using SystemPowiadomien;

namespace SystemPowiadomien
{
    internal class SmsOutput : IOutput
    {
        public void Send(string message)
        {
            Console.WriteLine($"SMS Wysyłanie wiadomości o treści: {message}");
        }
    }
}
