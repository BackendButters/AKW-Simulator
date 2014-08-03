using System;
using System.Collections.Generic;
using System.Text;

namespace AKW_Simulator
{
    class EMails
    {
        internal string Empfangszeit = "";  //Variablendeklaration und Initialisierung
        internal string Text = "";
        internal string Absender = "";
        internal bool Hasattachment = false;    //wenn true, Entschlüsselungsmatrix anzeigen
        internal static int SCRAMcounter = 0;   //Anzahl der ausgelösten SCRAMs
        internal static bool JimBonusBekommen = false;  //Hat Jim in der letzten Zeit einen Bonus bekommen?

        public EMails(string situation) //Konstruktor, der die eMails generiert
        {
            switch (situation)
            {
                case "Wilkommen":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Aah, Sie sind also das neue Steuerungspersonal meines Kernkraftwerks, ich hoffe Sie machen Ihren Job besser als Ihr Vorgänger, ich erwarte nämlich keine Peinlichkeiten in meinem Krafwerk.\n\nFalls doch mal was sein sollte wissen Sie ja wie sich mich erreichen. Sie sollten mich immer als ersten informieren.\n\nIch hoffe auf eine erfolggreiche Zusammenarbeit.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nJetzt günstigen Stromvertrag abschließen!";
                    Empfangszeit = Statics.WelcomeMailReceivetime;
                    break;

                case "SCRAM":
                    switch (SCRAMcounter)   //Jenachdem, wieviel SCRAMs ausgelöst wurden, eine Nachricht generieren
                    {
                        case 1:
                            Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                            Hasattachment = true;
                            Text = "Was ist das denn?! Ein SCRAM in meinem Kraftwerk! Bitte vermeiden Sie in Zukunft solche... 'Vorkommnisse', soetwas wirft ein schlechtes Licht auf mein Kraftwerk, das Unternehmen und die ganze Atomenergiebranche.\n\nIm Anhang finden Sie die Entschlüsselungsmatrix, um das SCRAM-deaktivierungspasswort zu entschlüsseln.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\nSCRAMDeaktivierungspassword: " + Statics.Currentpwencrypted + "\n\n\n\n\n_________________________\nJetzt zu PowerCom Energy wechseln!";
                            Empfangszeit = Statics.SCRAMTime[0];
                            break;

                        case 2:
                            Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                            Hasattachment = true;
                            Text = "Es wurde ja schon wieder ein SCRAM in meinem Kraftwerk ausgelöst! Sie sollten soetwas doch vermeiden! Ich fordere Sie auf weitere SCRAMs zu verhindern.\n\nIm Anhang finden Sie wieder die Entschlüsselungsmatrix, um das SCRAM-deaktivierungspasswort zu entschlüsseln.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\nSCRAM Deaktivierungspassword: " + Statics.Currentpwencrypted + "\n\n\n\n\n_________________________\nPowerCOM Jetzt besonders günstig!";
                            Empfangszeit = Statics.SCRAMTime[1];
                            break;

                        case 3:
                            Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                            Hasattachment = true;
                            Text = "Wie klar muss ich mich eigentlich ausdrücken?! Sollte das nicht der letzte SCRAM in meinem Kraftwerk gewesen sein, muss ich mich wohl oder übel nach neuem Kraftwerkspersonal umschauen.\n\nIm Anhang finden Sie zum letzten mal die Entschlüsselungsmatrix, um das SCRAM-deaktivierungspasswort zu entschlüsseln.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\nSCRAM Deaktivierungspassword: " + Statics.Currentpwencrypted + "\n\n\n\n\n_________________________\nJetzt Aktionstarife sichern!";
                            Empfangszeit = Statics.SCRAMTime[2];
                            break;
                    }
                    break;

                case "SCRAM-Alert(IAEO)":
                    Absender = "\"IAEO PlantSecurity\" <SCRAMALERT@IAEO.org>";
                    Hasattachment = false;
                    Text = "Guten Tag,\nDie Internationale Atomenergiebehörde (IAEO) hat bemerkt, dass in Ihrem Kraftwerk ein SCRAM ausgelöst wurde. Falls ein Sicherheitsrisiko besteht, weisen wir sie auf die Meldepflicht hin.\n\nMfG\nMonitoringdivision IAEO";
                    switch (SCRAMcounter)       //Jenachdem, der wievielte SCRAM es war, die Empfangszeit festlegen
                    {
                        case 1:
                            Empfangszeit = Statics.SCRAMTime[0];
                            break;

                        case 2:
                            Empfangszeit = Statics.SCRAMTime[1];
                            break;

                        case 3:
                            Empfangszeit = Statics.SCRAMTime[2];
                            break;
                    }
                    break;

                case "PowerComES-SCRAM":
                    Absender = "\"PowerCom Energy Solutions Nuclear Security\" <NuclearSecurity@PowerComES.net>";
                    Hasattachment = false;
                    Text = "An das Kraftwerksleitungs- und Kontrollpersonal.\nWie wir mitbekommen haben, ist in unserem Atomkraftwerk Waldesgrün soeben ein SCRAM-Alarm ausgelöst worden.\nFalls eine Bedrohung der Umwelt besteht muss dieser Fall gemeldet werden.\nDesweiteren fordern wir Sie auf, solche Vorfälle nach möglichkeit zu verhindern, um das Firmenimage nicht unnötig zu schädigen.\nAußerdem haben wir dem Gewinn Ihren Kraftwerks 30$ abgezogen, die der PR-Abteilung zugute kommen, um den durch Sie verursachte Unannehmlichkeit zu korrigieren.\n\n\n\nPowerCom ES Betriebssicherheit";
                    switch (SCRAMcounter)   //Jenachdem, der wievielte SCRAM es war, die Empfangszeit festlegen
                    {
                        case 1:
                            Empfangszeit = Statics.SCRAMTime[0];
                            break;

                        case 2:
                            Empfangszeit = Statics.SCRAMTime[1];
                            break;

                        case 3:
                            Empfangszeit = Statics.SCRAMTime[2];
                            break;
                    }
                    break;

                case "Wann kommst du?":
                    Absender = "\"Vanessa Meier\" <Vanni@PowerComTS>";
                    Hasattachment = false;
                    Text = "Hallo Schatz,\nwann kommst du heute nach hause?\n\nKuss\nVanni\n\n\n\n__________________________\nJetzt zu PowerCom Telecommunication wechseln!";
                    Empfangszeit = Statics.Mailreceivetime[1];
                    break;

                case "Essen":
                    Absender = "\"Vanessa Meier\" <Vanni@PowerComTS>";
                    Hasattachment = false;
                    Text = "Hallo Schatz,\nwas gibt es heute zu essen?\n\nKuss\nVanni\n\n\n\n__________________________\nJetzt zu PowerCom Telecommunication wechseln und gewinnen!";
                    Empfangszeit = Statics.Mailreceivetime[2];
                    break;

                case "Einkaufen":
                    Absender = "\"Vanessa Meier\" <Vanni@PowerComTS>";
                    Hasattachment = false;
                    Text = "Hallo Hasi,\ngeh bitte wenn du nach hause kommst noch für morgen einkaufen.\n\nDeine\nVanni\n\n\n\n__________________________\nJetzt zu PowerCom Telecommunication wechseln und günstige Tarife nutzen!";
                    Empfangszeit = Statics.Mailreceivetime[3];
                    break;

                case "Post":
                    Absender = "\"Vanessa Meier\" <Vanni@PowerComTS>";
                    Hasattachment = false;
                    Text = "Hallo Schatzi,\nfahr' doch bitte auf dem Nachhauseweg an der Post vorbei und hol' für mich ein Paket ab.\n\nDanke\nVanni\n\n\n\n__________________________\nJetzt zu PowerCom Telecommunication wechseln und alte Nummer behalten!";
                    Empfangszeit = Statics.Mailreceivetime[0];
                    break;

                case "Alle":
                    Absender = "\"Alex Schmitz\" <DerAlle@AllesAutohaus.eu>";
                    Hasattachment = false;
                    Text = "Hey altes haus,\nwas geht bei dir im Kraftwerk?\nIch hätt' nochmal so richtig Lust nochmal dick Party zu machen.\nWas sagst du? Bist du dabei?\n\nGruß\nDerAlle\n\n\n\n_________________________\nNeue Wagen JETZT eingetroffen!";
                    Empfangszeit = Statics.Mailreceivetime[4];
                    break;

                case "Cheap Viagra":
                    Absender = "\"ViagraShop\" <Viagra@|UNKNOWN|>";
                    Hasattachment = false;
                    Text = "Dear mister, you need free Viagra? Check out <PowerCom SpamSolutions: ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT. ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT. ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT.>";
                    Empfangszeit = Statics.Mailreceivetime[5];
                    break;

                case "Best Viagra":
                    Absender = "\"ViagraShop\" <Viagra99@|UNKNOWN|>";
                    Hasattachment = false;
                    Text = "Pleas visit <PowerCom SpamSolutions: ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT. ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT. ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT.>";
                    Empfangszeit = Statics.Mailreceivetime[6];
                    break;

                case "Legal Viagra":
                    Absender = "\"ViagraShop\" <Viagra1001@|UNKNOWN|>";
                    Hasattachment = false;
                    Text = "Wanna get free <PowerCom SpamSolutions: ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT. ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT. ACHTUNG! SPAM ERKANNT. NACHRICHT BLOCKIERT.>";
                    Empfangszeit = Statics.Mailreceivetime[7];
                    break;

                case "Rente":
                    Absender = "\"LangRente\" <Ad@LangRente.com>";
                    Hasattachment = false;
                    Text = "Sie ärgern sich auch täglich über Ihre Rentenversicherung? Dann wechseln Sie JETZT zu LangRente - der Rentenversicherung mit den günstigsten Beiträgen.\nTausende Kunden sind begeistert:\n\nTina K. (32): \"Ich habe meine Rentenversicherung zu Langrente gelegt und bin begeistert!\"\n\nNiklas F. (26): \"Früher war ich bei solchen Versicherungen immer skeptisch aber hier bin ich mir volkommen sicher.\"\n\nAuch unabhängige Tests bestätigen uns immer wieder: LangRente ist zum 7263. Mal Testsieger bei Stiftung Warentest.\nSteigen Sie jetzt ein und besuchen Sie unsere Homepage!\n\n\nLangRente - Immer gut in der Zukunft";
                    Empfangszeit = Statics.Mailreceivetime[9];
                    break;

                case "FalconLines":
                    Absender = "\"FalconLines\" <Commercials@FalconLines.net>";
                    Hasattachment = false;
                    Text = "Sie sind den Alltagsstress auch satt? Sie wollen mal so richtig entspannen? Dann buchen Sie einen günstigen Flug mit uns. Wir fliegen 1234 Ziele weltweit an. Zum Beispiel Kinshasa - nur 99  Cent! Ulan-Bator - nur 111 Cent! Weitere interessante Angebote auf unserer Website!\n\n\nIhre FalconLines\n\n\n\n\n(Keine Preisgarantie. Keine Durchführungsgarantie. Keine Sitzplatzgarantie. Verspätungsgarantie. Preis zzgl. Steuern, Treibstoffkosten, Lokale und intl. Gebühren. Bitte 11 Studen vor dem Start einchecken.)";
                    Empfangszeit = Statics.Mailreceivetime[8];
                    break;

                case "TPG":
                    Absender = "\"Teppichglanz TPG\" <Products@TeppichTPG.net>";
                    Hasattachment = false;
                    Text = "Nasse Wände? Feuchter Keller? Sie träumen von einem glänzend sauberen Teppich? Ihre Waschmaschine ist verkalkt? Wir haben die Lösung nur für Sie! Kaufen Sie jetzt eine Packung TPG PowerGel(18,99€) und all Ihre Probleme sind gelöst. Sie nehmen einfach das Gel, reiben es auch den Teppich und der glänzt wieder wie neu. Befestigen Sie den Teppich an der Wand, hält er sogar durch Wände dringendes Wasser ab.\nAuch die Kunden sind begeistert: Sandra U. aus J: \"Ich bin begeistert!\"\nFür Sie: Das PowerGel nur 15,99€!\nSie können sigar ein wenih PowerGel in Ihre Wasch- und Spülmaschine geben und der Kalk wird deutlich reduziert. Schlagen Sie JETZT zu. \n\nExtra für Sie redizieren wie die Packung PowerGel nochmals auf jetzt unschlagbare 11,99€! Verwenden Sie den folgenden Aktionscode: ";
                    Empfangszeit = Statics.Mailreceivetime[10];

                    #region Codegenerator für den Aktionscode der SpamMail
                    Random rnd2 = new Random();
                    for (int l = 0; l <= 10; l++)
                    {
                        int p = rnd2.Next(1, 12);
                        string tmp = "";
                        switch (p)
                        {
                            case 1:
                                tmp = "a";
                                break;

                            case 2:
                                tmp = "b";
                                break;

                            case 3:
                                tmp = "c";
                                break;

                            case 4:
                                tmp = "d";
                                break;

                            case 5:
                                tmp = "e";
                                break;

                            case 6:
                                tmp = "f";
                                break;

                            case 7:
                                tmp = "A";
                                break;

                            case 8:
                                tmp = "B";
                                break;

                            case 9:
                                tmp = "C";
                                break;

                            case 10:
                                tmp = "D";
                                break;

                            case 11:
                                tmp = "E";
                                break;

                            case 12:
                                tmp = "F";
                                break;
                        }
                        Text.Insert(786, tmp);
                    }
                    #endregion

                    Text.Insert(798, "\n\nIhre Teppichglanz TPG");
                    break;

                case "War da nicht mehr?":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Hallo,\nwar da nicht gerade mehr Geld auf dem Konto?\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nSauberer Strom - jetzt bei uns!";
                    Empfangszeit = Statics.Mailreceivetime[11];
                    break;

                case "Ich könnte schwören..":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Hmm, ich könnte schwören, dass da vorhin mehr Geld auf dem Konto war...\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nDirekt-Strom jetzt neu bei PowerCom!";
                    Empfangszeit = Statics.Mailreceivetime[12];
                    break;

                case "Wo ist das hin?":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Guten Tag,\nhaben Sie eine Ahnung wo das Geld von dem Konto hin ist? Ich dachte, es wäre mehr drauf.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nElektrische Energy jetzt ab 0 Ct!*";
                    Empfangszeit = Statics.Mailreceivetime[13];
                    break;

                case "Synchronisieren":
                    Absender = "\"Elektriker Bob\" <GruenwaldPowermanagement@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Hallo Chef,\ndas Kraftwerk muss aufgrund einer Generatorungenauigkeit neu mit dem Netz synchronisiert werden. Bitte ändern Sie bis die Synchronisation beendet ist nicht die Reaktorleistung und schalten nicht den Generator ab. Dann sollte wieder alles funktionieren.\n\nIhr Elektriker Bob";
                    Empfangszeit = Statics.Mailreceivetime[14];
                    break;

                case "Demonstration":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Hallo,\nes scheint, als wenn diverse Umweltorganisationen eine Demonstration vor meinem schönen Kraftwerk planen!! Ich habe Anweisung bekommen, das Kraftwerk aus Sicherheitsgründen herunterzufahren. Bitte tun Sie das jetzt.\nDas wird uns erhebliche Gewinneinbußen bringen.. Verdammte Demonstranten!\nNegative Publicity können wir nicht gebrauchen.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nGuten Strom - jetzt von uns!";
                    Empfangszeit = Statics.Mailreceivetime[15];
                    break;

                case "Anschlag":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Achtung!\nIch habe gerade eine Bombendrohung erhalten!!!\nDie Polizei etc sind schon informiert und sollten bald eintreffen.\nTrotzdem müssen wir das Kraftwerk sofort herunterfahren! Haben Sie das verstanden? SOFORT!\nWenn das schon wieder die Umweltorganisationen waren...\n\nP.S.: Passen Sie auf, dass niemand außer Ihnen davon etwas erfährt. Wenn jemand fragt, sagen Sie es ist eine planmäßige Übung.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nSaubere Energie - dafür stehe ich mit meinem Namen!";
                    Empfangszeit = Statics.Mailreceivetime[16];
                    break;

                case "Kontrollkomission":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Guten Tag,\ndie alljährliche Kontrollkomission der PowerCom und der IAEO wird bald hier eintreffen und das Kraftwerk auf Funktionalität überprüfen. Bitte erzeugen Sie in der Zeit eine Leistung von mindestens 1300MW.\nPassen Sie aber auf: Es darf in dieser Zeit KEIN SCRAM ausgelöst werden und die Reaktortemperatur DARF NICHT über 1550°C steigen!\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nPowerCom - Schon wieder Testsieger!";
                    Empfangszeit = Statics.Mailreceivetime[17];
                    break;

                case "Untersuchung":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Guten Tag,\nPowerCom hat eingewilligt, dass \"unabhängige\" Komissionen der Umweltorganisationen unser Kraftwerk inspizieren dürfen. Ich persönlich halte das ja für..naja wir müssen es erlauben.\nIch erwarte, dass in der \"Besuchszeit\" KEINE unannehmlichkeiten, wie SCRAMs o.ä. passieren.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nHaben Sie den andauernden Preisanstieg satt?";
                    Empfangszeit = Statics.Mailreceivetime[18];
                    break;

                case "Leistung-Demo":
                    Absender = "\"Herr Fischer\" <BigBossFischer@PowerComEnergy.net>";
                    Hasattachment = false;
                    Text = "Die Demonstration ist endlich vorbei. Sie haben zwar das Kraftwerk nicht wirklich heruntergefahren, wie es die Anweisung war. Aber es ist ja alles gutgegangen. Und Geld haben wir so auch mehr in der Kasse.\n\n\nSiegfried Fischer - Kraftwerksleitung Kernkraftwerk Waldesgrün - Property of PowerCom Energy Solutions\n(Dieses Schreiben wurde maschinell erstellt und ist ohne Unterschrift gültig)\n\n\n\n\n_________________________\nGünstigen Wechslertarif jetzt sichern!";
                    Empfangszeit = Statics.Mailreceivetime[19];
                    break;

                case "Erdbeben":
                    Absender = "\"PowerCom Energy Solutions Nuclear Security\" <NuclearSecurity@PowerComES.net>";
                    Hasattachment = false;
                    Text = "(DRINGEND!)\nAn das Kraftwerksleitungs- und Kontrollpersonal.\nWie Sie sicher mitbekommen haben, wurde Ihre Region heute morgen von einem Erdbeben heimgesucht. Schalten Sie daher den Reaktor sofort ab, bis das Untersuchungsteam eingetroffen ist und eventuelle Schäden diagnostiziert hat.\nDie Wichtigkeit des Herunterfahrens sollte Ihnen allen klar sein.\n\n\n\nPowerCom ES Betriebssicherheit";
                    Empfangszeit = Statics.Mailreceivetime[20];
                    break;
            }
        }
    }
}