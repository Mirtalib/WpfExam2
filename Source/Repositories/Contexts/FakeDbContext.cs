using Newtonsoft.Json;
using Source.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Repositories.Contexts;

public class FakeDbContext
{
    public static List<User?>? Users { get; set; } = new();
    public static List<User> GetUsers()
    {
        var stringData = File.ReadAllText("../../../UserInfoFile.json");
        Users = JsonConvert.DeserializeObject<List<User>>(stringData)!;
        return Users;
    }
    public static void WriteUsers()
    {
        var jsonString = JsonConvert.SerializeObject(Users, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText("../../../UserInfoFile.json", jsonString);
    }

    

}
