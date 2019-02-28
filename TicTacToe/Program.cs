using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Eingaben
    {
        public static string NutzerEingabe(string eing)
        {
            eing = Console.ReadLine();
            return eing;
        }

        public static string ÜberprüfeObIndexLeer(string eing, List<string> Liste)
        {
            int index;
            bool richtig = false;
            while (richtig == false)
            {
                eing = FrageObPassend(eing);

                switch (eing)
                {
                    case "A0":
                        index = 0;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    case "B0":
                        index = 1;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    case "C0":
                        index = 2;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    case "A1":
                        index = 3;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    case "B1":
                        index = 4;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    case "C1":
                        index = 5;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    case "A2":
                        index = 6;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    case "B2":
                        index = 7;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    case "C2":
                        index = 8;
                        richtig = Ausgaben.FrageObNötig(richtig, eing, index, Liste);
                        eing = FrageObLeer(eing, index, Liste);
                        break;
                    default:
                        richtig = true;
                        break;
                }
            }
            return eing;
        }

        public static string FrageObLeer(string eing, int index, List<string> Liste)
        {
            if (Liste[index] != " ")
            {
                Console.WriteLine("In diesem Feld ist schon etwas, bitte geben Sie eine neue vorhandene Koordinate ein!: ");
                eing = NutzerEingabe(eing);
                Verarbeitung.AbfrageObNeu(eing);
            }
            return eing;
        }

        public static string FrageObPassend(string eing)
        {
            while(eing != "A0" && eing != "A1" && eing != "A2" && eing != "B0" && eing != "B1" && eing != "B2" && eing != "C0" && eing != "C1" && eing != "C2")
            {
                Console.WriteLine("Geben Sie eine Gültige  Koordinate ein: ");
                eing = NutzerEingabe(eing);
                Verarbeitung.AbfrageObNeu(eing);
            }
            return eing;
        }
    }

    public class Ausgaben
    {
        public static void FeldZeichnen(List<string> Liste)
        {
            Console.WriteLine("  A B C\n0 {0}|{1}|{2}\n  -+-+-\n1 {3}|{4}|{5}\n  -+-+-\n2 {6}|{7}|{8}", Liste[0], Liste[1], Liste[2], Liste[3], Liste[4], Liste[5], Liste[6], Liste[7], Liste[8]);
        }

        public static bool FrageObNötig(bool richtig, string eing, int index, List<string> Liste)
        {
            if (Liste[index] == " ")
            {
                richtig = true;
            }
            return richtig;
        }

        public static bool ÜberprüfeObEnde(int zug, List<string> Liste)
        {
            if (Liste[0] == "X" && Liste[1] == "X" && Liste[2] == "X" || Liste[3] == "X" && Liste[4] == "X" && Liste[5] == "X" || Liste[6] == "X" && Liste[7] == "X" && Liste[8] == "X" || Liste[0] == "X" && Liste[3] == "X" && Liste[6] == "X" || Liste[1] == "X" && Liste[4] == "X" && Liste[7] == "X" || Liste[2] == "X" && Liste[5] == "X" && Liste[8] == "X" || Liste[0] == "X" && Liste[4] == "X" && Liste[8] == "X" || Liste[2] == "X" && Liste[4] == "X" && Liste[6] == "X")
            {
                Console.WriteLine("Spieler 1 hat gewonnen! X-X-X");
                return false;
            }
            else if (Liste[0] == "O" && Liste[1] == "O" && Liste[2] == "O" || Liste[3] == "O" && Liste[4] == "O" && Liste[5] == "O" || Liste[6] == "O" && Liste[7] == "O" && Liste[8] == "O" || Liste[0] == "O" && Liste[3] == "O" && Liste[6] == "O" || Liste[1] == "O" && Liste[4] == "O" && Liste[7] == "O" || Liste[2] == "O" && Liste[5] == "O" && Liste[8] == "O" || Liste[0] == "O" && Liste[4] == "O" && Liste[8] == "O" || Liste[2] == "O" && Liste[4] == "O" && Liste[6] == "O")
            {
                Console.WriteLine("Spieler 2 hat gewonnen! O-O-O");
                return false;
            }
            else if (zug == 10)
            {
                Console.WriteLine("Das war der Letzte Zug... Unentschieden!!!");
                Console.WriteLine("Wenn Sie das Spiel beenden wollen, geben sie 'ende' ein");
                return false;
            }
            return true;
        }
    }

    public class Verarbeitung
    {
        public static List<string> KoordinateInListe(string eing, int zug, List<string> Liste)
        {
            switch (eing)
            {
                case "A0":
                    Liste[0] = XOderO(zug);
                    break;
                case "B0":
                    Liste[1] = XOderO(zug);
                    break;
                case "C0":
                    Liste[2] = XOderO(zug);
                    break;
                case "A1":
                    Liste[3] = XOderO(zug);
                    break;
                case "B1":
                    Liste[4] = XOderO(zug);
                    break;
                case "C1":
                    Liste[5] = XOderO(zug);
                    break;
                case "A2":
                    Liste[6] = XOderO(zug);
                    break;
                case "B2":
                    Liste[7] = XOderO(zug);
                    break;
                case "C2":
                    Liste[8] = XOderO(zug);
                    break;
            }
            return Liste;
        }

        public static string XOderO(int zug)
        {
            if (zug % 2 == 0)
            {
                return "O";
            }
            else
            {
                return "X";
            }
        }

        public static void AbfrageObNeu(string eingabe)
        {
            if (eingabe.ToLower() == "ende")
            {
                Environment.Exit(0);
            }
            else if (eingabe.ToLower() == "neu")
            {
                Program.Programm();
                // return eingabe;
            }
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Programm();
            }
            
        }

        public static string Programm()
        {
            int zug = 1;
            string eingabe = "";
            List<string> EingabeListe = new List<string> { " ", " ", " ", " ", " ", " ", " ", " ", " " };
            Ausgaben.FeldZeichnen(EingabeListe);
            bool nochmal = true;

            do
            {
                eingabe = Eingaben.NutzerEingabe(eingabe);
                Verarbeitung.AbfrageObNeu(eingabe);

                eingabe = Eingaben.ÜberprüfeObIndexLeer(eingabe, EingabeListe);

                EingabeListe = Verarbeitung.KoordinateInListe(eingabe, zug, EingabeListe);
                zug++;
                Ausgaben.FeldZeichnen(EingabeListe);
                nochmal = Ausgaben.ÜberprüfeObEnde(zug, EingabeListe);
            } while (nochmal);
            return "fertig";
        }

        
    }
}
