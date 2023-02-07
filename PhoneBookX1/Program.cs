using PhoneBookX1.Models;

namespace PhoneBookX1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Count() < 2)
            {
                Usage();
                return;
            }

            PhoneBookContext context = new PhoneBookContext();
            context.Database.EnsureCreated();

            /*
            Contact c1 = new Contact() { PhoneNumber = "089-123456", Name = "Jemmy Ned", Address = "One Tree Hill" };
            Contact c2 = new Contact() { PhoneNumber = "01-555456", Name = "Mary Mac", Address = "One Rock Road" };
            Contact c3 = new Contact() { PhoneNumber = "048-555444", Name = "Jonny Joe", Address = "2 Main St" };
            Contact c4 = new Contact() { PhoneNumber = "021-333222", Name = "Billy McBurty", Address = "55 Five Lines Road" };

                        context.Contacts.Add(c1);
                        context.Contacts.Add(c2);
                        context.Contacts.Add(c3);
                        context.Contacts.Add(c4);
                        context.SaveChanges();*/

  
            switch (args[0])
            {
                case "add":
                    if (args.Count() < 4) { Console.WriteLine("Missing field(s)!"); return; }
                            AddRecord(context, new Contact() { PhoneNumber = args[1], Name = args[2], Address = args[3] });
                    break;
                case "upd": UpdateRecord(context, new Contact() { PhoneNumber = args[1], Name = args[2], Address = args[3] });
                    break;
                case "del": DeleteRecord(context, args[1]);
                    break;
            }

            foreach (Contact contact in context.Contacts)
            {
                Console.WriteLine(contact.Name);
            }
        }

        private static void AddRecord(PhoneBookContext phoneBookContext, Contact contact)
        {
            phoneBookContext.Contacts.Add(contact);
            phoneBookContext.SaveChanges(); 
        }

        private static void Usage()
        {
            Console.WriteLine("***Usage:");
            Console.WriteLine();
            Console.WriteLine("**PhoneBookX1.exe [command], [Phone Number], {Name}, {Address}");
            Console.WriteLine();
        }

        static void UpdateRecord(PhoneBookContext pbx, Contact contact)
        {
            try
            {
                var found = pbx.Contacts.Find(contact.PhoneNumber);
                if (found != null)
                {
                    found.Address = contact.Address;
                    found.Name = contact.Name;
                    pbx.SaveChanges();
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("ERROR: "+ex.Message);
            }
        }

        static void DeleteRecord(PhoneBookContext pbx, string number)
        {
            try
            {
                var found = pbx.Contacts.Find(number);
                if (found != null)
                {
                    pbx.Remove(found);
                    pbx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

    }
}