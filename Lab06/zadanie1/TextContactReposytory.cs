using System;
using System.Collections.Generic;
using System.IO;

namespace Lab06.zadanie1
{
    internal class TxtContactRepository
    {
        private readonly string _path;

        public TxtContactRepository(string path)
        {
            _path = path;
            EnsureFileExists();
        }

        private void EnsureFileExists()
        {
            if (!File.Exists(_path))
                File.Create(_path).Close();
        }

        public List<Contact> GetAll()
        {
            var contacts = new List<Contact>();

            foreach (var line in File.ReadAllLines(_path))
            {
                var parts = line.Split(';');
                if (parts.Length == 3)
                {
                    contacts.Add(new Contact
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Email = parts[2]
                    });
                }
            }
            return contacts;
        }

        public void Add(Contact contact)
        {
            var line = $"{contact.Id};{contact.Name};{contact.Email}";
            File.AppendAllLines(_path, new[] { line });
        }
    }
}

