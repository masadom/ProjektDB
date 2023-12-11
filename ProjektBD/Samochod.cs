﻿using System.ComponentModel.DataAnnotations;

public class Samochod
{
    [Key]
    public int SamochodId { get; set; }

    public string Marka { get; set; }
    public string Model { get; set; }
    public string NumerRejestracyjny { get; set; }
    public int RokProdukcji { get; set; }
    public bool Dostepny { get; set; }
    public decimal CenaZaDzien { get; set; }
}
