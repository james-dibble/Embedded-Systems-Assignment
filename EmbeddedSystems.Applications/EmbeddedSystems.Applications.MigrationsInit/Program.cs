namespace EmbeddedSystems.Applications.MigrationsInit
{
    using System;

    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    class Program
    {
        static void Main(string[] args)

        {
            using (var db = new Context())
            {
                Console.WriteLine("Creating database context using connection string:");
                Console.WriteLine(db.Database.Connection.ConnectionString);

                db.Handsets.Add(new Handset { HandsetNumber = "Something" });
                db.SaveChanges();
                db.Handsets.RemoveRange(db.Handsets);
            }

            Console.WriteLine("All done!");

            Console.ReadLine();
        }
    }
}
