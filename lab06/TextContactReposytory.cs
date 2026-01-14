using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab06
{
    internal class TextContactReposytory
    {
        // nazwa pliku
        private readonly string _path;

        // konstruktor klasy z parametrem do ścieżki

        public TextContactReposytory(string path)
        {
            _path = path;
            EnsureFileExists();
        }
        private void EnsureFileExists() {
            if (File.Exists(_path))
                File.WriteAllText(_path, "");

    }
}
