namespace ContactWeb.Migrations
{
    using ContactWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            CreateStates(context);
        }

        private void CreateStates(ApplicationDbContext context)
        {
            foreach (var state in SeedStates)
            {
                var exist = context.States.FirstOrDefault(x => x.Name.Equals(state.Name, StringComparison.OrdinalIgnoreCase)
                    && x.Abbreviation.Equals(state.Abbreviation, StringComparison.OrdinalIgnoreCase));
                if (exist == null)
                {
                    context.States.Add(state);
                }
                context.SaveChanges();

            }
        }
        private static List<State> SeedStates = new List<State>
        {
            new State(){Name="Andhra Pradesh", Abbreviation="AP"},
            new State(){Name="Arunachal Pradesh", Abbreviation="AR"},
             new State(){Name="Assam", Abbreviation="AS"},
             new State(){Name="Bihar", Abbreviation="BR"},
             new State(){Name="Chhattisgarh", Abbreviation="CG"},
             new State(){Name="Goa", Abbreviation="GA"},
            new State(){Name="Gujarat", Abbreviation="GJ"},
             new State(){Name="Haryana", Abbreviation="HR"},
             new State(){Name="Himachal Pradesh", Abbreviation="HP"},
             new State(){Name="Jammu and Kashmir", Abbreviation="JK"},
             new State(){Name="Jharkhand", Abbreviation="JH"},
             new State(){Name="Jharkhand", Abbreviation="KA"},
             new State(){Name="Kerala", Abbreviation="KL"},
             new State(){Name="Madhya Pradesh", Abbreviation="MP"},
             new State(){Name="Maharashtra", Abbreviation="MH"},
             new State(){Name="Manipur", Abbreviation="MN"},
             new State(){Name="Meghalaya", Abbreviation="ML"},
             new State(){Name="Mizoram", Abbreviation="MZ"},
             new State(){Name="Nagaland", Abbreviation="NL"},
             new State(){Name="Orissa", Abbreviation="OR"},
             new State(){Name="Punjab", Abbreviation="PB"},
             new State(){Name="Rajasthan", Abbreviation="RJ"}
        };
    }
}
