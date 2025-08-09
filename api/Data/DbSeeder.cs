using System;
using api.Data;
using api.models;

public static class DbSeeder
{
   
   // Intègre des données d'origine dans la bases de données
    public static async Task SeedAsync(JPVerbLearnerContext context)
   {
      if (!context.ClassExample.Any())
      {
         var listExample = new List<classExample>();

         await context.SaveChangesAsync();
      }
   }
}
