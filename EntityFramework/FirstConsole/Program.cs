using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsole
{
    class Program
    {
        /// <summary>
        /// 创建记录
        /// </summary>
        /// <param name="context">数据库连接对象</param>
        static void Create(Context context)
        {
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
        /// <summary>
        /// 读取记录
        /// </summary>
        /// <param name="context">数据库连接对象</param>
        static void Read(Context context)
        {
            var donators = context.Donators;
            Console.WriteLine("Id\t\t姓名\t\t金额\t\t赞助日期");
            foreach (var donator in donators)

            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", donator.DonatorId, donator.Name, donator.Amount, donator.DonateDate.ToShortDateString());
            }
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="context"></param>
        static void Update(Context context)
        {
            var donators = context.Donators;
            if (donators.Any())
            {
                var toBeUpdatedDonator = donators.First(d => d.Name == "醉千秋");
                toBeUpdatedDonator.Name = "醉、千秋";
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="context"></param>
        static void Delete(Context context)
        {
            var donators = context.Donators;
            var tobedelete = donators.Single(n => n.Name == "linjie");
            if (tobedelete != null)
            {
                donators.Remove(tobedelete);
                context.SaveChangesAsync();
            }
        }

        static void Main(string[] args)
        {
            Database.SetInitializer(new Initializer());
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
                    {
                       // Create(context);
                        Console.WriteLine("Database was NOT created."); 
                        Console.WriteLine("reading from database.");
                        Read(context);
                        Update(context);
                        Read(context);
                        
                    }
                    var payways = context.PayWays;
                    foreach (var item in payways)
                    {
                        Console.WriteLine(item.Name);
                    }

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
