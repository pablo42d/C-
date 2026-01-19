using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Lab06.zadanie2
{
    internal class PopulationRepository
    {
        private List<PopulationRecord> _data;

        public PopulationRepository(string path)
        {
            var json = File.ReadAllText(path);
            _data = JsonSerializer.Deserialize<List<PopulationRecord>>(json)!;
        }

        public int? GetPopulation(string country, int year)
        {
            var record = _data.FirstOrDefault(x =>
                x.Country.Id == country &&
                x.Date == year.ToString() &&
                x.Value != null);

            if (record == null)
                return null;

            return int.Parse(record.Value!);
        }

        public int GetDifference(string country, int from, int to)
        {
            var a = GetPopulation(country, from);
            var b = GetPopulation(country, to);

            if (a == null || b == null)
                throw new Exception("Brak danych");

            return b.Value - a.Value;
        }

        public void ShowPercentageGrowth(string country)
        {
            var list = _data
                .Where(x => x.Country.Id == country && x.Value != null)
                .OrderBy(x => int.Parse(x.Date))
                .ToList();

            for (int i = 1; i < list.Count; i++)
            {
                int prev = int.Parse(list[i - 1].Value!);
                int curr = int.Parse(list[i].Value!);

                double growth = (curr - prev) / (double)prev * 100;
                Console.WriteLine($"{list[i - 1].Date} → {list[i].Date}: {growth:F2}%");
            }
        }
    }
}
