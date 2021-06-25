using System;
using System.Collections.Generic;
using System.Linq;
using Week6.Test.Assicurazione.Models;
using Week6.Test.Assicurazione.Repositories;

namespace Week6.Test.Assicurazione
{
    class Program
    {
        public static RepositoryPolicy repoPolicy = new RepositoryPolicy();
        public static RepositoryClient repoClient = new RepositoryClient();

        static void Main(string[] args)
        {
            bool keepGoing;
            do
            {
                ShowMenu();
                keepGoing = AnalyzeChoice(ReadInt(5));

            } while (keepGoing);
        }

        private static void ShowMenu()
        {
            int choice; 
            bool keepGoing;

            Console.WriteLine("----- Menu -----\n" +
                "1. Inserire nuovo cliente\n" +
                "2. Inserire nuova polizza" +
                "3. Associare polizza per un cliente\n" +
                "4. Stampare polizza con dati cliente\n" +
                "5. Uscire");
        }

        private static bool AnalyzeChoice(int choice)
        {
            bool keepGoing = true;
            switch(choice)
            {   
                case 1:
                    InsertClient();
                    break;
                case 2:
                    InsertPolicy();
                    break;
                case 3:
                    AssociatePolicyClient();
                    break;
                case 4:
                    ShowAll();
                    break;
                case 5:
                    keepGoing = false;
                    break;
            }
            return keepGoing;
        }

        private static void InsertPolicy()
        {
            int choice;
            bool succ;
            Policy policy;
            string number;
            float insuredAmount, monthlyRate;
            DateTime dateDrafting;
            Console.WriteLine("Che tipo di polizza si vuole?\n" +
                "1. Car insurance\n" +
                "2. Theft policy\n" +
                "3. Life policy\n");
            choice = ReadInt(3);

            Console.WriteLine("Numero?");
            number = Console.ReadLine();
            Console.WriteLine("Date drafting?");
            do
            {
                succ = DateTime.TryParse(Console.ReadLine(), out dateDrafting);
            } while (!succ);
            Console.WriteLine("Insured amount?");
            do
            {
                succ = float.TryParse(Console.ReadLine(), out insuredAmount);
            } while (!succ);
            Console.WriteLine("Monthly rate?");
            do
            {
                succ = float.TryParse(Console.ReadLine(), out monthlyRate);
            } while (!succ);
            switch(choice)
            {
                case 1:
                    policy = new CarInsurance();
                    Console.WriteLine("Plate?");
                    string plate = Console.ReadLine();
                    Console.WriteLine("Displacement?");
                    int displacement = ReadInt(Int32.MaxValue);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private static void ShowAll()
        {
            repoPolicy.ShowPoliciesWithClients();
        }

        private static void AssociatePolicyClient()
        {
            ICollection<Policy> policies = repoPolicy.GetAll();
            ICollection<Client> clients = repoClient.GetAll();
            bool r = false;


            if (policies.Count == 0)
            {
                Console.WriteLine("Non è presente alcuna polizza al momento.");
                r = true;
            }
            if(clients.Count == 0)
            {
                Console.WriteLine("Non è presente alcun cliente al momento.");
                r = true;
            }

            if (r)
                return;
            Console.WriteLine("Questi sono i clienti, scegli un codice fiscale:");
            Helper.ShowRecords<Client>(clients);
            Console.WriteLine("Codice fiscale?");
            string clientCF = Console.ReadLine();

            Console.WriteLine("Queste sono le polizze, scegli un numero:");
            Helper.ShowRecords<Policy>(policies);
            Console.WriteLine("Numero di polizza?");
            int nrPolicy = ReadInt(policies.Max(p => p.Number));
            if (repoClient.AddPolicy(clientCF, nrPolicy))
                Console.WriteLine("Polizza aggiunta con successo");
            else
                Console.WriteLine("Errore nell'aggiunta della polizza");
        }

        private static void InsertClient()
        {
            string CF, name, surname, address;

            Console.WriteLine("Codice fiscale?");
            CF = Console.ReadLine();
            Console.WriteLine("Nome?");
            name = Console.ReadLine();
            Console.WriteLine("Cognome?");
            surname = Console.ReadLine();
            Console.WriteLine("Indirizzo?");
            address = Console.ReadLine();

            repoClient.Create(new Client
            {
                Address = address,
                CF = CF,
                Name = name,
                Surname = surname
            });

        }

        private static int ReadInt(int maxInt)
        {
            bool done;
            int choice;
            do
            {
                done = Int32.TryParse(Console.ReadLine(), out choice);
                if (!done || choice <= 0 || choice > maxInt)
                    Console.Write("Format not correct. Retry: ");
            }
            while (!done || choice <= 0 || choice > maxInt);

            return choice;
        }
    }
}
