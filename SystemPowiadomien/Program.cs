// System Powiadomień (Interfejsy)
// Aplikacja konsolowa w C# umożliwiająca wysyłanie powiadomień za pomocą różnych metod (SMS, Email) przy użyciu interfejsów.
// tworzy interfejs IOutput z metodą Send(string message).
// implementuje dwie klasy: SmsOutput i EmailOutput, które implementują interfejs IOutput.
// w metodzie Main tworzy instancje obu klas i wywołuje metodę Send z przykładową wiadomością.
using SystemPowiadomien;

List<IOutput> powiadomienia = new List<IOutput>();
powiadomienia.Add(new SmsOutput());
powiadomienia.Add(new EmailOutput());

string wiadomosc = "To jest testowe powiadomienie.";

foreach (var powiadomienie in powiadomienia)
{
    powiadomienie.Send(wiadomosc);
}

Console.WriteLine("Wszystkie powiadomienia zostały wysłane.");

