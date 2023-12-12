using ProjektBD;
using System;
using System.Data.Entity;

class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Jaką tabele chcesz zmodyfikować klient=k, samochod=s");
        string table = Console.ReadLine();
        if (table.ToUpper() == "k")
        {



            Console.WriteLine("Jesli chcesz dodać napisz a, jesli chcesz znalezc pracownika napisz g, jesli chcesz zmodyfikowac napisz b,jesli chcesz usunąc napisz u ");
            string check = Console.ReadLine();
            if (check.ToUpper() == "A")
            {
                AddClient();
            }
            else if (check.ToUpper() == "G")
            {
                Console.WriteLine("podaj id klienta");
                int idKlienta = int.Parse(Console.ReadLine());
                GetClient(idKlienta);
            }
            else if (check.ToUpper() == "B")
            {
                Console.WriteLine("podaj id klienta którego chcesz zmodyfikować");
                int idKlienta = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj nowe imie klienta");
                string newName = Console.ReadLine();
                Console.WriteLine("Podaj nowy email klienta");
                string newEmail = Console.ReadLine();
                UpdateCustomer(idKlienta, newName, newEmail);
            }
            else if (check.ToUpper() == "U")
            {
                Console.WriteLine("podaj id klienta");
                int idKlienta = int.Parse(Console.ReadLine());
                DeleteCustomer(idKlienta);
            }
        }
        else if(table.ToUpper() == "s")
        {
            Console.WriteLine("Jesli chcesz dodać napisz a, jesli chcesz znalezc samochod napisz g, jesli chcesz zmodyfikowac napisz b,jesli chcesz usunąc napisz u ");
            string check = Console.ReadLine();
            if (check.ToUpper() == "A")
            {
                AddCar();
            }
            else if (check.ToUpper() == "G")
            {
                Console.WriteLine("podaj id samochodu");
                int carid = int.Parse(Console.ReadLine());
                GetCar(carid);
            }
            else if (check.ToUpper() == "B")
            {
                Console.WriteLine("podaj id samochodu którego chcesz zmodyfikować");
                int carid = int.Parse(Console.ReadLine());
                Console.WriteLine("Podaj nową marke");
                string newMarka = Console.ReadLine();
                Console.WriteLine("Podaj nowy model");
                string newModel = Console.ReadLine();
                Console.WriteLine("Podaj nowy numer rejestracyjny");
                string numerRejestracyjny = Console.ReadLine();
                UpdateCar(carid, newMarka, newModel, numerRejestracyjny);
            }
            else if (check.ToUpper() == "U")
            {
                Console.WriteLine("podaj id samochodu");
                int carId = int.Parse(Console.ReadLine());
                DeleteCar(carId);
            }
        }
    }

    //client/customer methods
    static void AddClient()
    {
        using (var ctx = new wypozyczalnia())
        {
            Console.WriteLine("Podaj imie");
            string imie = Console.ReadLine();
            Console.WriteLine("Podaj Nazwisko");
            string nazwisko = Console.ReadLine();
            Console.WriteLine("Podaj Adres");
            string adres = Console.ReadLine();
            Console.WriteLine("Podaj Numer telefonu");
            string nrtel = Console.ReadLine();
            Console.WriteLine("Podaj emial");
            string email = Console.ReadLine();
            var stud = new Klient() { Imie = imie, Nazwisko = nazwisko, Adres = adres, NumerTelefonu = nrtel, Email = email };

            ctx.Klient.Add(stud);
            ctx.SaveChanges();
        }
    }

    static void GetClient(int clientid)
    {
        using (var ctx = new wypozyczalnia())
        {
            int clientIdToFind = 1; // ID pracownika do znalezienia
            var foundclient = ctx.Klient.FirstOrDefault(e => e.KlientId == clientIdToFind);
            if (foundclient != null)
            {
                Console.WriteLine($"Znaleziono klienta: {foundclient.Imie} {foundclient.Nazwisko}");
            }
        }
    }

    static void UpdateCustomer(int customerId, string newName, string newEmail)
    {
        using (var ctx = new wypozyczalnia())
        {
            var customerToUpdate = ctx.Klient.FirstOrDefault(c => c.KlientId == customerId);
            if (customerToUpdate != null)
            {
                customerToUpdate.Imie = newName;
                customerToUpdate.Email = newEmail;
                ctx.SaveChanges(); // Zapisz zmiany w bazie danych
                Console.WriteLine("Dane klienta zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono klienta o podanym ID.");
            }
        }
    }

    static void DeleteCustomer(int customerId)
    {
        using (var ctx = new wypozyczalnia())
        {
            var customerToDelete = ctx.Klient.FirstOrDefault(c => c.KlientId == customerId);
            if (customerToDelete != null)
            {
                ctx.Klient.Remove(customerToDelete);
                ctx.SaveChanges(); // Zapisz zmiany w bazie danych
                Console.WriteLine("Klient został pomyślnie usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono klienta o podanym ID.");
            }
        }
    }


    static void AddCar()
    {
        using (var ctx = new wypozyczalnia())
        {
            Console.WriteLine("Podaj marke");
            string marka = Console.ReadLine();
            Console.WriteLine("Podaj Model");
            string Model = Console.ReadLine();
            Console.WriteLine("Podaj Cene Za Dzien (decimal)");
            decimal CenaZaDzien = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Podaj RokProdukcji (int)");
            int RokProdukcji =int.Parse( Console.ReadLine());
            Console.WriteLine("Podaj czy Dostepny (bool)");
            bool Dostepny =bool.Parse( Console.ReadLine());
            Console.WriteLine("Podaj Numer Rejestracyjny");
            string NumerRejestracyjny = Console.ReadLine();
            var stud = new Samochod() { Marka = marka, Model = Model, CenaZaDzien = CenaZaDzien, RokProdukcji = RokProdukcji, Dostepny = Dostepny, NumerRejestracyjny = NumerRejestracyjny };

            ctx.Samochod.Add(stud);
            ctx.SaveChanges();
        }
    }

    static void GetCar(int carid)
    {
        using (var ctx = new wypozyczalnia())
        {
            int carIdToFind = carid; 
            var foundcar = ctx.Samochod.FirstOrDefault(e => e.SamochodId == carIdToFind);
            if (foundcar != null)
            {
                Console.WriteLine($"Znaleziony samochód: {foundcar.Marka} {foundcar.Model}");
            }
        }
    }

    static void UpdateCar(int carId, string newMarka, string newModel, string NumerRejestracyjny)
    {
        using (var ctx = new wypozyczalnia())
        {
            var carToUpdate = ctx.Samochod.FirstOrDefault(c => c.SamochodId == carId);
            if (carToUpdate != null)
            {
                carToUpdate.Marka = newMarka;
                carToUpdate.Model = newModel;
                carToUpdate.NumerRejestracyjny = NumerRejestracyjny;
                ctx.SaveChanges(); // Zapisz zmiany w bazie danych
                Console.WriteLine("Dane samochodu zostały zaktualizowane.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono samochodu o podanym ID.");
            }
        }
    }


    static void DeleteCar(int carid)
    {
        using (var ctx = new wypozyczalnia())
        {
            var carToDelete = ctx.Samochod.FirstOrDefault(c => c.SamochodId == carid);
            if (carToDelete != null)
            {
                ctx.Samochod.Remove(carToDelete);
                ctx.SaveChanges(); // Zapisz zmiany w bazie danych
                Console.WriteLine("Samochud został pomyślnie usunięty.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono samochodu o podanym ID.");
            }
        }
    }
}
