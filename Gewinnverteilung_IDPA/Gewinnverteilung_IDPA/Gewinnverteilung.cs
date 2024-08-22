using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gewinnverteilung_IDPA
{
    internal class Gewinnverteilung
    {
        private decimal jahresgewinn;
        private decimal aktienkapital;
        private decimal partizipationskapital;
        private decimal gesetzlicheReserven;
        private decimal gewinnVortrag;
        private decimal gewuenschteDividende;

        public decimal ErsterBeitragReserven { get; private set; }
        public decimal ZweiterBeitragReserven { get; private set; }
        public decimal Ausschuettung { get; private set; }
        public decimal NeuerGewinnVortrag { get; private set; }

        public Gewinnverteilung(decimal jahresgewinn, decimal aktienkapital, decimal partizipationskapital, decimal gesetzlicheReserven, decimal gewinnVortrag, decimal gewuenschteDividende)
        {
            this.jahresgewinn = jahresgewinn;
            this.aktienkapital = aktienkapital;
            this.partizipationskapital = partizipationskapital;
            this.gesetzlicheReserven = gesetzlicheReserven;
            this.gewinnVortrag = gewinnVortrag;
            this.gewuenschteDividende = gewuenschteDividende;
        }

        public void BerechneVerteilung()
        {
           
            if (gewuenschteDividende < 0)
            {
                throw new ArgumentException("Die gewünschte Dividende kann nicht negativ sein.");
            }

            decimal maxDividende = jahresgewinn + gewinnVortrag;
            if (gewuenschteDividende > maxDividende)
            {
                throw new ArgumentException($"Die gewünschte Dividende überschreitet den maximalen Betrag von {maxDividende:C}.");
            }

            
            ErsterBeitragReserven = jahresgewinn * 0.05m;
            if (ErsterBeitragReserven + gesetzlicheReserven > aktienkapital * 0.20m)
            {
                ErsterBeitragReserven = aktienkapital * 0.20m - gesetzlicheReserven;
            }

            
            Ausschuettung = gewuenschteDividende;
            if (gewuenschteDividende > aktienkapital * 0.05m)
            {
                ZweiterBeitragReserven = (gewuenschteDividende - aktienkapital * 0.05m) * 0.10m;
            }
            else
            {
                ZweiterBeitragReserven = 0;
            }

            
            NeuerGewinnVortrag = jahresgewinn + gewinnVortrag - ErsterBeitragReserven - ZweiterBeitragReserven - Ausschuettung;
        }
    }
}

  