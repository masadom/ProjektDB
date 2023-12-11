using System.ComponentModel.DataAnnotations;

public class Klient
{
    [Key]
    public int KlientId { get; set; }

    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Adres { get; set; }
    public string NumerTelefonu { get; set; }
    public string Email { get; set; }
}
