using System;
using System.Linq;
using System.Collections.Generic;

namespace LambdaExamples
{
    class Learner
    {
        public string FullName { get; set; }
        public int Score { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("------------Odd Numbers Average----------");
            int[] series = { 2, 5, 7, 10, 11, 13 };
            double avg = series.Where(n => n % 2 != 0).Average();
            Console.WriteLine("Odd Numbers Average: " + avg);

            Console.WriteLine();
            Console.WriteLine("------------Filter with Statement Lambda----------");
            int[] data = { 2, 4, 9, 11, 3, 6 };
            var filtered = data.Where(x => {
                if (x < 5) return true;
                if (x > 10) return true;
                return false;
            });
            Console.WriteLine("Filtered Numbers (x < 5 or x > 10):");
            foreach (var num in filtered) Console.WriteLine(num);

            Console.WriteLine();
            Console.WriteLine("------------Square Numbers----------");
            var squares = Enumerable.Range(1, 5).Select(n => n * n).ToArray();
            Console.WriteLine("Squares: " + string.Join(" - ", squares));

            Console.WriteLine();
            Console.WriteLine("------------Any Condition Check----------");
            var items = new[] {
                new { Price = 200, InStock = 0 },
                new { Price = 150, InStock = 5 }
            };
            bool matchFound = items.Any(i => i.Price > 180 && i.InStock == 0);
            Console.WriteLine("Any Item Price > 180 and Out of Stock: " + matchFound);

            Console.WriteLine();
            Console.WriteLine("------------Count Specific City----------");
            var users = new[] {
                new { Name = "Sara", Location = "Berlin" },
                new { Name = "Mike", Location = "Berlin" },
                new { Name = "Emma", Location = "Rome" }
            };
            int berlinUsers = users.Count(u => u.Location == "Berlin");
            Console.WriteLine("Users from Berlin: " + berlinUsers);

            Console.WriteLine();
            Console.WriteLine("------------Total Yearly Orders----------");
            int targetYear = 2023;
            var clients = new[] {
                new {
                    FullName = "David",
                    Orders = new[] {
                        new { Date = new DateTime(2023, 5, 10), Amount = 120m },
                        new { Date = new DateTime(2022, 8, 15), Amount = 80m }
                    }
                }
            };
            var summary = clients.Select(c => new {
                c.FullName,
                YearTotal = c.Orders.Where(o => o.Date.Year == targetYear).Sum(o => o.Amount)
            });
            Console.WriteLine("Yearly Order Total:");
            foreach (var s in summary)
                Console.WriteLine($"{s.FullName}: {s.YearTotal}");

            Console.WriteLine();
            Console.WriteLine("------------Minimum Price in Each Group----------");
            var catalog = new[] {
                new { Type = "Book", Price = 250 },
                new { Type = "Book", Price = 150 },
                new { Type = "Gadget", Price = 500 }
            };
            var grouped = catalog.GroupBy(c => c.Type)
                .Select(g => new { Category = g.Key, Lowest = g.Min(x => x.Price) });
            Console.WriteLine("Minimum Price in Each Group:");
            foreach (var g in grouped)
                Console.WriteLine($"{g.Category}: {g.Lowest}");

            Console.WriteLine();
            Console.WriteLine("------------Maximum Total Order----------");
            var buyers = new[] {
                new {
                    Name = "Sophia",
                    Orders = new[] {
                        new { Date = new DateTime(2024, 1, 5), Total = 250m },
                        new { Date = new DateTime(2024, 3, 22), Total = 400m }
                    }
                }
            };
            var maxTotal = buyers.SelectMany(b => b.Orders)
                .Where(o => o.Date.Year == 2024)
                .Max(o => o.Total);
            Console.WriteLine("Max Order Total in 2024: " + maxTotal);


            Console.WriteLine();
            Console.WriteLine("------------Average Per Person----------");
            var people = new[] {
                new {
                    Name = "Liam",
                    Purchases = new[] {
                        new { Cost = 300m },
                        new { Cost = 100m }
                    }
                }
            };
            var stats = people.Select(p => new {
                p.Name,
                AvgSpent = p.Purchases.Average(x => x.Cost)
            });
            Console.WriteLine("Average Spent Per Person:");
            foreach (var stat in stats)
                Console.WriteLine($"{stat.Name}: {stat.AvgSpent}");


            Console.WriteLine();
            Console.WriteLine("------------Constant Return Using Lambda----------");
            Func<string> sayHi = () => "Hello!";
            Console.WriteLine("sayHi(): " + sayHi());


            Console.WriteLine();
            Console.WriteLine("------------Add 10----------");
            Func<int, int> plusTen = n => n + 10;
            Console.WriteLine("plusTen(25): " + plusTen(25));


            Console.WriteLine();
            Console.WriteLine("------------Print and Return----------");
            Func<string, int> printLength = text => {
                Console.WriteLine("Printing inside Lambda: " + text);
                return text.Length;
            };
            int len = printLength("Lambda!");
            Console.WriteLine("Length Returned: " + len);


            Console.WriteLine();
            Console.WriteLine("------------Cube Using Lambda----------");
            Func<int, int> cube = n => n * n * n;
            Console.WriteLine("cube(3): " + cube(3));


            Console.WriteLine();
            Console.WriteLine("------------Multiply Two Numbers----------");
            Func<int, int, int> multiply = (x, y) => x * y;
            Console.WriteLine("multiply(4, 6): " + multiply(4, 6));


            Console.WriteLine();
            Console.WriteLine("------------Even Numbers from List----------");
            List<int> values = new List<int> { 12, 7, 3, 20, 25 };
            var result = values.Where(v => v % 2 == 0).ToList();
            Console.WriteLine("Even Numbers:");
            result.ForEach(Console.WriteLine);


            Console.WriteLine();
            Console.WriteLine("------------Filter Students-------");
            List<Learner> list = new List<Learner> {
                new Learner { FullName = "Zara", Score = 90 },
                new Learner { FullName = "Tom", Score = 65 },
                new Learner { FullName = "Nina", Score = 78 }
            };
            var passed = list.Where(l => l.Score >= 70).ToList();
            Console.WriteLine("Students Passed:");
            passed.ForEach(l => Console.WriteLine($"{l.FullName}: {l.Score}"));
        }
    }
}
