using System.ComponentModel.DataAnnotations;

public class Klient
{
    public int KlientId { get; set; }

    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Adres { get; set; }
    public string NumerTelefonu { get; set; }
    public string Email { get; set; }
    public ICollection<Klient> Klienci { get; set; }

}
