using System;
using System.Collections.Generic;
using Lab05;

public class Zamowienie
{
	public int Numer { get; set; }
	public List<string> Produkty { get; set; }
	public StatusZamowienia Status { get; set; }

    public Zamowienie(int numer, List<string> produkty)
	{
		Numer = numer;
		Produkty = produkty;
		Status = StatusZamowienia.Oczekujące;
    }
}
