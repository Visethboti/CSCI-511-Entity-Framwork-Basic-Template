using System;
using System.Linq;

namespace CSCI511_Project_4
{
    internal class Program
    {
        private static void Main()
        {
            //runInsertExample();
            //runReadExample();
            //runDeleteEverything();
            //runUpdateExample();
            //runReadExample();
            //runQueryExample();
            //runJoinExample();
            runJoinExample2();
        }

        private static void runInsertExample() {
            using (var db = new CSCI511_Proj4_DB()) {
                Console.WriteLine("Inserting into Veterinarian Table");
                db.Add(new Veterinarian { Vid = 3, Name = "George" });
                db.Add(new Veterinarian { Vid = 5, Name = "Nancy" });
                db.SaveChanges();

                Console.WriteLine("Inserting into Dogs Table");
                db.Add(new Dog { Did = 7, DogName = "Spot", Age = 10 });
                db.Add(new Dog { Did = 19, DogName = "Rocky", Age = 1 });
                db.Add(new Dog { Did = 10, DogName = "Tiger", Age = 5 });
                db.Add(new Dog { Did = 8, DogName = "Sleepy", Age = 4 });
                db.SaveChanges();

                Console.WriteLine("Inserting into Examines Table");
                db.Add(new Examine { Vid = 5, Did = 8, Fee = 20 }); 
                db.Add(new Examine { Vid = 5, Did = 19, Fee = 40 });
                db.Add(new Examine { Vid = 5, Did = 10, Fee = 30 });
                db.Add(new Examine { Vid = 3, Did = 7, Fee = 30 });
                db.Add(new Examine { Vid = 3, Did = 8, Fee = 40 });
                db.SaveChanges();
            }
        }

        private static void runReadExample() {
            using (var db = new CSCI511_Proj4_DB())
            {
                var veterinarianTable = db.Veterinarians.OrderBy(v =>v.Vid);
                Console.WriteLine("Veterinarian Table:");
                foreach (var v in veterinarianTable)
                {
                    Console.WriteLine(v.Vid + " " + v.Name);
                }

                var DogsTable = db.Dogs.OrderBy(d => d.Did);
                Console.WriteLine("Dogs Table:");
                foreach (var d in DogsTable)
                {
                    Console.WriteLine(d.Did + " " + d.DogName + " " + d.Age);
                }

                var ExaminesTable = db.Examines.OrderBy(e => e.Vid);
                Console.WriteLine("Examines Table:");
                foreach (var e in ExaminesTable)
                {
                    Console.WriteLine(e.Vid + " " + e.Did + " " + e.Fee);
                }
            }
        }

        private static void runDeleteEverything() {
            using (var db = new CSCI511_Proj4_DB())
            {
                var veterinarianTable = db.Veterinarians;
                Console.WriteLine("Deleting all veterinarian...");
                foreach (var v in veterinarianTable)
                {
                    db.Remove(v);
                }

                var DogsTable = db.Dogs;
                Console.WriteLine("Deleting all dogs...");
                foreach (var d in DogsTable)
                {
                    db.Remove(d);
                }

                var ExaminesTable = db.Examines;
                Console.WriteLine("Deleting all examines...");
                foreach (var e in ExaminesTable)
                {
                    db.Remove(e);
                }

                db.SaveChanges();
            }
        }

        private static void runUpdateExample()
        {
            using (var db = new CSCI511_Proj4_DB())
            {
                
                Console.WriteLine("Updating Examine fee...");
                var dog = db.Dogs.SingleOrDefault(d => d.Did == 7);
                dog.Age = 11;

                db.SaveChanges();
            }
        }

        private static void runQueryExample()
        {
            using (var db = new CSCI511_Proj4_DB()) 
            {
                var DogsTable = db.Dogs.Where(d => d.Age < 10);
                Console.WriteLine("Query Dogs with Age < 10");
                foreach (var d in DogsTable)
                {
                    Console.WriteLine(d.Did + " " + d.DogName + " " + d.Age);
                }
            }
        }

        private static void runJoinExample()
        {
            using (var db = new CSCI511_Proj4_DB())
            {
                var data = db.Veterinarians
                .Join(
                    db.Examines,    
                    Veterinarian => Veterinarian.Vid,
                    Examine => Examine.Vid,
                    (Veterinarian, Examine) => new
                    {
                        Vid = Veterinarian.Vid,
                        Name = Veterinarian.Name,
                        Fee = Examine.Fee
                    }
                ).ToList();

                Console.WriteLine("Result of joining Examine with Veterinarian");
                foreach (var i in data)
                {
                    Console.WriteLine(i.Vid + " " + i.Name + " " + i.Fee);
                }
            }
        }

        private static void runJoinExample2()
        {
            using (var db = new CSCI511_Proj4_DB())
            {
                var data = db.Examines
                .Join(
                    db.Veterinarians,
                    Examine => Examine.Vid,
                    Veterinarian => Veterinarian.Vid,
                    (Examine, Veterinarian) => new
                    {
                        Vid = Veterinarian.Vid,
                        Name = Veterinarian.Name,
                        Fee = Examine.Fee,
                        Did = Examine.Did,
                    }
                )
                 .Join(
                    db.Dogs,
                    Dog => Dog.Did,
                    Examine => Examine.Did,
                    (Examine, Dog) => new
                    {
                        Vid = Examine.Vid,
                        Name = Examine.Name,
                        Fee = Examine.Fee,
                        Did = Dog.Did,
                        DogName = Dog.DogName
                    }
                ).ToList();

                Console.WriteLine("Result of joining Examine with Veterinarian and Dog");
                foreach (var i in data)
                {
                    Console.WriteLine(i.Vid + " " + i.Name + " " + i.Fee + " " + i.Did + " " + i.DogName );
                }
            }
        }
    }
}