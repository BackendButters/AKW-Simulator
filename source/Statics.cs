using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AKW_Simulator
{
    class Statics
    {
        //Diese Klasse beinhaltet statische Variablen und Methoden

        #region Variablendeklaration
        internal static int Jimbonus = 0; //Die Summe der Prämien, die Jim erhalten hat
        internal static decimal Guthaben = 50;  //Guthaben
        static string[] password = new string[20] { "Woodcrafter", "Forrestal", "Coral Sea", "GLaDOS", "Einstein", "Fichte", "Casablanca", "Peleliu", "Zugspitze", "Pazifik", "Roboter", "Infrarot", "Indien", "Fuchs", "Ahorn", "Automobil", "Senator", "Jimi Hendrix", "Indianapolis", "Cormorant" }; //Mögliche Passwörter
        static bool[] pwused = new bool[20] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }; //Variable, die sicherstellt, dass die Passwörter nicht 2x vorkommen
        internal static bool[] externComponentToRep = new bool[8]; //Gibt die ID der Komponenten an, die von HypeRep repariert werden sollen
        internal static string Currentpw = "";  //das momentane Passwort (unverschlüsselt)
        internal static string Currentpwencrypted = ""; //Das momentane Passwort (verschlüsselt)
        static string tmp = ""; //Hilfsvariable für die Passwortverschlüsselung
        internal static string[] Mailreceivetime = new string[21];  //Empfangszeit der eMails
        internal static string WelcomeMailReceivetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(); //eMailempfangszeit der Wilkommensnachricht
        internal static string[] SCRAMTime = new string[3]; //Auslösezeit der SCRAMs
        internal static bool Steuerstaberror = false; //Steuerstab kaputt?
        internal static int Steuerstab_repdauer;    //Reparaturdauer des Steuerstabs
        internal static int Steuerstabrepweg = 121; //Weg zur Reparatur des Steuerstabs
        internal static bool TurbineError = false;  //Turbine kaputt?
        internal static bool GeneratorError = false;    //Generator kaputt?
        internal static bool KuhlwasserNachfullPumpeError = false;  //Kühlwassernachfüllpumpe kaputt?
        internal static double FilterVerstopfung = 10;  //Filterverstopfung in Prozent
        internal static int FilterWeg = 35; //Reparaturweg zum Filter
        internal static int GeneratorWeg = 63;  //Reparaturweg zum Generator
        internal static int TurbineWeg = 58;    //Reparaturweg zur Turbine
        internal static int KuhlwassernachfullpumpeWeg = 72;    //Reparaturweg zur Kühlwassernachfüllpumpe
        internal static int FilterRepdauer = 20;    //Reparaturdauer des Filters
        internal static int GeneratorRepdauer = 81; //Reparaturdauer des Generators
        internal static int TurbineRepdauer = 28;   //Reparaturdauer der Turbine
        internal static int KuhlwassernachfullpumpeRepdauer = 32;   //Reparaturdauer der Kühlwassernachfüllpumpe
        internal static bool TurbineRepRequest = false; //Soll die Turbine repariert werden?
        internal static bool GeneratorRepRequest = false;   //Soll der Generator repariert werden?
        internal static bool KuhlwasserNachfullPumpeRepRequest = false; //Soll die Kühlwassernachfüllpumpe repariert werden?
        internal static bool FilterRepRequest = false;  //Soll der Filter gereinigt werden?
        internal static int Messagerepeat = 0;  //Hilfsvariable, um Chatspam zu vermeiden
        internal static int Chatrepeat = 0;     //s.o.
        internal static int GeldMail = 0;       //Counter für eMails vom Chef, wenn man Jim Geld gegeben hat
        internal static bool Event = false;     //läuft gerade ein Event?
        internal static string Eventname = "";  //Name des Events
        internal static int EventBegin = 0;     //Dauer bis zum Beginn des Events
        internal static int EventDauer = 0;     //Dauer des Events (wird in der Eventlogik dekrementiert)
        internal static int Eventleistung = 0;  //Leistung, die während des Events gebracht wurde
        internal static int EventdauerFix = 0;  //Dauer des jeweiligen Events (fix)
        internal static int NichtErbrachteLeistung = 0; //Leistung, die gefordert, aber nicht gebracht wurde
        internal static decimal P2l = 60;   //Pumpe 2 Leistung
        internal static decimal P1l = 60;   //Pumpe 1 Leistung
        internal static decimal Epl = 0;    //Ersatzpumpe Leistiung
        internal static decimal Leistung = 0;   //gewollte Reaktorleistung
        internal static decimal Temperatur = 150;   //Reaktortemperatur
        internal static bool Pumpe1_working = true; //Pumpe 1 defekt?
        internal static bool Pumpe2_working = true; //Pumpe 2 defekt?
        internal static bool Ersatzpumpe_working = true;    //Ersatzpumpe defekt?
        internal static bool Technikoccupied = false;   //techniker beschäftigt?
        internal static bool Reparing = false;          //Techniker bei der Reparatur?
        internal static int Demandleistung = 800;       //geforderte Leistung
        internal static byte P1repweg = 50;     //Reparaturweg zur Pumpe 1
        internal static int P1repdauer = 0;     //Reparaturdauer Pumpe 1
        internal static byte P2repweg = 80;     //Reparaturweg zur Pumpe 2
        internal static int P2repdauer = 0;     //Reparaturdauer Pumpe 2
        internal static byte Eprepweg = 110;    //Reparaturweg zur Ersatzpumpe       
        internal static int Eprepdauer = 0;     //Reparaturdauer Ersatzpumpe
        internal static int Mwpreis = 550;      //Preis pro MW
        internal static bool JimTurnschuhe = false;  //Jim genug Prämie bekommen, um neue Turnschuhe zu kaufen?
        internal static bool Mukkibude = false;      //Jim genug Prämie bekommen, um im Fitnesstudio gewesen zu sein?
        internal static decimal Gesamtpumpenleistung = 0;   //Gesamtleistung aller Kühlwasserpumpen
        internal static bool Fueling = false;       //Kühlwasserbecken wird gefüllt?
        internal static string Lastreperatur = "";  //Name der Komponente, an der Jim das letzte mal war
        internal static decimal Istleistung = 50;   //gelieferte Leistung
        internal static bool RepStopp = false;      //Jim zurückgerufen?
        internal static bool pause = false;         //Spiel pausiert? 
        #endregion 

        static string Encryption(string buchstabe)  //Rot-13 Verschlüsselungsmethode
        {
            switch (buchstabe)
            {
                case "a":
                    return "n";

                case "b":
                    return "o";

                case "c":
                    return "p";

                case "d":
                    return "q";

                case "e":
                    return "r";

                case "f":
                    return "s";

                case "g":
                    return "t";

                case "h":
                    return "u";

                case "i":
                    return "v";

                case "j":
                    return "w";

                case "k":
                    return "x";

                case "l":
                    return "y";

                case "m":
                    return "z";

                case "n":
                    return "a";

                case "o":
                    return "b";

                case "p":
                    return "c";

                case "q":
                    return "d";

                case "r":
                    return "e";

                case "s":
                    return "f";

                case "t":
                    return "g";

                case "u":
                    return "h";

                case "v":
                    return "i";

                case "w":
                    return "j";

                case "x":
                    return "k";

                case "y":
                    return "l";

                case "z":
                    return "m";

                case "A":
                    return "N";

                case "B":
                    return "O";

                case "C":
                    return "P";

                case "D":
                    return "Q";

                case "E":
                    return "R";

                case "F":
                    return "S";

                case "G":
                    return "T";

                case "H":
                    return "U";

                case "I":
                    return "V";

                case "J":
                    return "W";

                case "K":
                    return "X";

                case "L":
                    return "Y";

                case "M":
                    return "Z";

                case "N":
                    return "A";

                case "O":
                    return "B";

                case "P":
                    return "C";

                case "Q":
                    return "D";

                case "R":
                    return "E";

                case "S":
                    return "F";

                case "T":
                    return "G";

                case "U":
                    return "H";

                case "V":
                    return "I";

                case "W":
                    return "J";

                case "X":
                    return "K";

                case "Y":
                    return "L";

                case "Z":
                    return "M";

                case " ":
                    return " ";
            }
            return "";
        }  

        internal static void Passwordchoose()   //Passwortgenerator
        {
            Random rnd = new Random();
            for (int tempcount = 1; tempcount >0; tempcount++)
            {
                int i = rnd.Next(0, 20);    //Passwort auswählen
                if (!pwused[i])             //Wenn Passwort noch nicht benutzt wurde..
                {
                    Currentpw = password[i];    //ausgesuchtes Passwort dem momentanen zuweisen
                    pwused[i] = true;           //Passwort als "benutzt" setzen
                    Currentpwencrypted = "";    //Verschlüsseltes-Passwort-Variable initialisieren
                    for (int k = 1; k <= Currentpw.Length; ++k) //Schleife, die nach der Reihe die Buchstaben des Passwortes verschlüsselt und dem momentanen Passwort zuweist
                    {
                        tmp = "";
                        tmp = Currentpw.Substring(k - 1, 1);
                        Currentpwencrypted += Encryption(tmp);
                    }
                    tempcount = -1; //Wenn verschlüsselung abgeschlossen, schleifenabbruch
                }
            }
        }

        internal static bool ConnectionAvailable()  //Prüft Serververbindung zum Highscore- und Newsserver
        {
            System.Uri masterserverURL = new System.Uri("http://www.fssnet-n.de");
            System.Net.WebRequest request;
            request = System.Net.WebRequest.Create(masterserverURL);
            request.Timeout = 2000;
            System.Net.WebResponse objResp;
            try
            {
                objResp = request.GetResponse();
                objResp.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
