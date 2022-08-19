using System.Text.Json;
using System;
using System.Text;
using UploadSpiders;
using UploadSpiders.Model;

//
// A little program to upload our JSON aranae.json file to the database.
// Used scaffolding to create the Model classes:
//
// dotnet ef dbcontext scaffold "connection-string" Pomelo.EntityFrameworkCore.MySql -o Model -f
//
// Should probably move the model files to their own project, but they can stay here for the moment,
// as this is just a little test of APIs and Fargate, or whatever it turns in to.
//

var filename = args[0];
if (filename == null)
{
    Console.WriteLine("Null filename not allowed.");
    return;
}
Console.WriteLine($"File: {filename}");
var connect = args[1];
if (connect == null)
{
    Console.WriteLine("Null connection string not allowed.");
    return;
}
Console.WriteLine($"Connect: {connect}");

var file = File.ReadAllText(filename);
var records = JsonSerializer.Deserialize<Dictionary<string, List<Species>>>(file);

if (records == null)
{
    Console.WriteLine("Null serialized records object.");
    return;
}

List<Family> families = new List<Family>();
Dictionary<string, List<Species>> species = new Dictionary<string, List<Species>>();

foreach (var (k, v) in records)
{
    Family f = new Family()
    {
        Name = k, Id = Guid.NewGuid().ToString()
    };
    species.Add(f.Id, new List<Species>());
    foreach (var sp in v)
    {
        //f.AddSpecies(sp);
        sp.Id = Guid.NewGuid().ToString();
        sp.Family = f.Id;
        species[f.Id].Add(sp);
        Console.WriteLine($"{k} = {sp}");
    }
    families.Add(f);
}

using (var context = new UploadSpiders.Model.SpidersContext(connect))
//using (var con = new MySql.Data.MySqlClient.MySqlConnection(connect))
{
    //con.Open();
    foreach (var fam in families)
    {
        //using (var cmd = new MySql.Data.MySqlClient.MySqlCommand($"INSERT INTO Families (Id, Name) VALUES ('{fam.Id.ToString()}', '{fam.Name}')"))
        //{
        //    cmd.Connection = con;
        //    var d = cmd.ExecuteNonQuery();
        //    Console.WriteLine($"{fam.Name} = {d}");
        //}

        context.Families.Add(fam);
        foreach (var sp in species[fam.Id])
        {
            context.Species.Add(sp);
        }
        context.SaveChanges();
    }
}
