using System;

namespace Gewinnverteilung_IDPA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Jahresgewinn: ");
            decimal jahresgewinn = decimal.Parse(Console.ReadLine());

            Console.Write("Aktienkapital: ");
            decimal aktienkapital = decimal.Parse(Console.ReadLine());

            Console.Write("Partizipationskapital: ");
            decimal partizipationskapital = decimal.Parse(Console.ReadLine());

            Console.Write("Gesetzliche Reserven: ");
            decimal gesetzlicheReserven = decimal.Parse(Console.ReadLine());

            Console.Write("Gewinn- oder Verlustvortrag: ");
            decimal gewinnVortrag = decimal.Parse(Console.ReadLine());

            Console.Write("Gewünschte Dividende: ");
            decimal gewuenschteDividende = decimal.Parse(Console.ReadLine());

            try
            {
              
                Gewinnverteilung verteilung = new Gewinnverteilung(jahresgewinn, aktienkapital, partizipationskapital, gesetzlicheReserven, gewinnVortrag, gewuenschteDividende);

                
                verteilung.BerechneVerteilung();

               
                Console.WriteLine();
                Console.WriteLine("Ergebnisse:");
                Console.WriteLine($"Erster Beitrag zur gesetzlichen Reserve: {verteilung.ErsterBeitragReserven:C}");
                Console.WriteLine($"Zweiter Beitrag zur gesetzlichen Reserve: {verteilung.ZweiterBeitragReserven:C}");
                Console.WriteLine($"Ausschüttung (Grund- und Superdividende): {verteilung.Ausschuettung:C}");
                Console.WriteLine($"Gewinn- oder Verlustvortrag für die nächste Rechnung: {verteilung.NeuerGewinnVortrag:C}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}

   