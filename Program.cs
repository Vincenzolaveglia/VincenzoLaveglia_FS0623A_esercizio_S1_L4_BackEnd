namespace EsercizioLezione4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScriviMenu();
        }

        public static void ScriviMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("=============== OPERAZIONI ===============");
            Console.WriteLine("Scegli operazione da effettuare: ");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");

            var scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    User.Login();
                    break;
                case "2":
                    User.Logout();
                    break;
                case "3":
                    User.StampaDataEOraLogin();
                    break;
                case "4":
                    User.StampaListaAccessi();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
            }
            ScriviMenu();
        }
    }

    public static class User
    {
        public static string username;
        public static string password;
        public static bool isLogged;
        public static DateTime DataOraLog;
        public static List<DateTime> Accessi = new List<DateTime>();

        public static void Login()
        {
            Console.WriteLine("Inserisci username: ");
            User.username = Console.ReadLine();
            Console.WriteLine("Inserisci password: ");
            User.password = Console.ReadLine();
            Console.WriteLine("Conferma password: ");
            string conferma = Console.ReadLine();

            if ((User.password == conferma) && (User.username != " "))
            {
                isLogged = true;
                DataOraLog = DateTime.Now;
                Accessi.Add(DataOraLog);
                Console.WriteLine($"Utente riconosciuto loggato il {DataOraLog}");
            }
            else
            {
                Console.WriteLine("Impossibile effetuare il login");
            }
        }

        public static void Logout()
        {
            username = "";
            password = "";
            isLogged = false;
            Console.WriteLine("Logout avvenuto con successo");
        }

        public static void StampaDataEOraLogin()
        {
            if (User.isLogged == true)
            {
                Console.WriteLine($"L'utente {User.username} ha effettuato l'accesso il {User.DataOraLog}");
            }
            else
            {
                Console.WriteLine("Non risultano utenti loggati al sistema");
            }
        }

        public static void StampaListaAccessi()
        {
            if (Accessi.Count > 0)
            {
                Console.WriteLine("Lista degli accessi:");
                foreach (var accesso in Accessi)
                {
                    Console.WriteLine($"L'utente {User.username} ha loggato il {accesso}");
                }
            }
            else
            {
                Console.WriteLine("Nessun accesso registrato.");
            }
        }
    }
}
