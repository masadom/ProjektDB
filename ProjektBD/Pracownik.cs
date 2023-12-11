﻿using System;
using System.ComponentModel.DataAnnotations;

public class Pracownik
{
    [Key]
    public int PracownikId { get; set; }

    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Stanowisko { get; set; }
    public DateTime DataZatrudnienia { get; set; }
    public string Email { get; set; }
    public string NumerTelefonu { get; set; }
}
