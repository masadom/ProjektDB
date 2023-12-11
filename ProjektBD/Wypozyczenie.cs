﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Wypozyczenie
{
    [Key]
    public int WypozyczenieId { get; set; }

    [ForeignKey("Samochod")]
    public int SamochodId { get; set; }
    public Samochod Samochod { get; set; }

    [ForeignKey("Klient")]
    public int KlientId { get; set; }
    public Klient Klient { get; set; }

    public DateTime DataWypozyczenia { get; set; }
    public DateTime DataZwrotu { get; set; }
    public decimal OplataZaWypozyczenie { get; set; }
    public bool StatusZwrotu { get; set; }
}
