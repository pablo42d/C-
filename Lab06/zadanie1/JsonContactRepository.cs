using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lab06.zadanie1
{
    internal class JsonContactRepository
    {
        private readonly string _path;

        public JsonContactRepository(string path)
        {
            _path = path;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_path))
                File.WriteAllText(_path, "[]");
        }

        public List<Contact> GetAll()
        {
            var json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }

        public void Add(Contact contact)
        {
            var contacts = GetAll();
            contacts.Add(contact);

            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_path, json);
        }
    }
}

