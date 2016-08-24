using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                try
                {
                    bool created = context.Database.CreateIfNotExists();
                    if (created)
                    {

                        Console.WriteLine("Database is created.");
                       
                    }
                    else
                        Console.WriteLine("Database was NOT created.");
                    var donators = new List<Donator>
                             {
                            new Donator
                            {
                              Name   = "陈志康",
                              Amount = 50,
                              DonateDate = new DateTime(2016, 4, 7)
                            },
                            new Donator
                            {
                                Name = "海风",
                                Amount = 5,
                                DonateDate = new DateTime(2016, 4, 8)
                            },
                            new Donator
                            {
                                Name = "醉千秋",
                                Amount = 18.8m,
                                DonateDate = new DateTime(2016, 4, 15)
                            }
                        };

                    context.Donators.AddRange(donators);
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
