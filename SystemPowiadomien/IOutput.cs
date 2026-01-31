using System;
using System.Collections.Generic;
using System.Text;
using SystemPowiadomien;

namespace SystemPowiadomien
{
    internal interface IOutput
    {
        void Send(string message);
    }
}
