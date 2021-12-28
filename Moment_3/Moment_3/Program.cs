
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;



namespace Moment_3
{

    class Guest
    {
        private object guest;


        public Guest(object guest)
        {
            this.guest = guest;
        }


        internal void ToArray()
        {
            throw new NotImplementedException();
        }

        internal void RemoveAt(int v)
        {
            throw new NotImplementedException();
        }
    }


    class Message
    {

        private static void Main()
        {
            while (true)
            {
                //Menyn för gästboken
                Console.WriteLine("Välkommen till Elin Backlunds gästbok");
                Console.WriteLine("1. Skriv i gästboken!");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("3. Avsluta");



                //Skriva ut gästbokens innehåll
                try
                {

                    //Streamreader för att läsa guestbook.txt
                    using StreamReader sr = new StreamReader(Directory.GetCurrentDirectory().ToString() + "\\guestbook.txt");
                    //Gör om till List
                    List<string> guests = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + "\\guestbook.txt").ToList();
                    //Loopar igenom inlägg för att skriva till skärm
                    for (var i = 0; i < guests.Count; i++)
                    {
                        Console.WriteLine($"[{i}] - {guests[i]}");
                    }


                }
                //Fehanterare
                catch (Exception)
                {
                    Console.WriteLine("Skapar guestbook.txt...");

                }
                //Variabel för att läsa in gästens val
                int choice = int.Parse(Console.ReadLine());

                //Rensar konsollen
                Console.Clear();
                //Switchsats för de olika alternativen
                switch (choice)
                { //Alternativ 1

                    case 1:
                        //lGästen fyller i sitt namn
                        Console.WriteLine("Fyll i ditt namn:");
                        string namn = Console.ReadLine();

                        //Felhantering ifall gästen inte matat in korrekt
                        if (namn.Length == 0)
                        {
                            Console.WriteLine("Starta om och fyll i ditt namn!");
                        }
                        else
                        {

                            //Gästen skriver sitt inlägg
                            Console.WriteLine("Skriv ditt inlägg till gästboken:");
                            string medd = Console.ReadLine();


                            //Felhantering ifall gästen inte skriver in något meddelande
                            if (medd.Length == 0)
                            {
                                Console.WriteLine("Starta om programmet och fyll i meddelande korrekt");
                            }
                            else
                            {
                                //Spara namn till textfilen
                                File.AppendAllText(Directory.GetCurrentDirectory().ToString() + "\\guestbook.txt", "Namn: " + namn);
                                //Spara meddelandet till textfilen
                                File.AppendAllText(Directory.GetCurrentDirectory().ToString() + "\\guestbook.txt", " - Meddelande: " + medd + "\n");

                                try
                                {
                                    //Streamreader för att läsa i gästboken
                                    using StreamReader sr = new StreamReader(Directory.GetCurrentDirectory().ToString() + "\\guestbook.txt");
                                    //Gör om till lista
                                    List<string> guests = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + "\\guestbook.txt").ToList();
                                    //Loopa och sätt index på inläggen
                                    for (var i = 0; i < guests.Count; i++)
                                    {
                                        Console.WriteLine($"[{i}] - {guests[i]}");
                                    }


                                }
                                //Felhanterare ifall något går fel
                                catch (Exception e)
                                {
                                    Console.WriteLine("Filen kunde inte läsas:");
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }


                        //Slut på alternativ 1
                        break;
                    //Alternativ 2
                    case 2:
                        Console.WriteLine("Skriv nummer på det inlägg du vill radera:");

                        //Radera
                        List<string> line = new List<string>();
                        //Läser in vad gästen skrivit
                        var guestoption = Console.ReadLine();
                        line = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + "\\guestbook.txt").ToList();

                        //raderar det gästen valt
                        line.RemoveAt(int.Parse(guestoption));
                        //Sparar om
                        File.WriteAllLines(Directory.GetCurrentDirectory().ToString() + "\\guestbook.txt", line.ToArray());


                        //Slut på alternativ 2
                        break;
                    //Alternativ 3 
                    case 3:
                        // Avslutar program

                        Environment.Exit(1);
                        break;
                }


            }

        }
    }

}