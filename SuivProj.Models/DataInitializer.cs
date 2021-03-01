using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SuivProj.Models.Classes;
using SuivProj.Models.DataAccess;

namespace SuivProj.Models
{
    public class DataInitializer
    {
        public static async Task SeedUserData(DataBaseContext context)
        {
            if (!context.Utilisateur.Any())
            {
                var File = System.IO.File.ReadAllText("user.seeder.json");
                var Utilisateurs = JsonSerializer.Deserialize<List<Utilisateur>>(File);

                await context.Utilisateur.AddRangeAsync(Utilisateurs);
                await context.SaveChangesAsync();
            }
        }

    }
}
