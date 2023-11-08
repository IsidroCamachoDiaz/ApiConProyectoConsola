using System.Text.Json;
using System.Text.Json.Serialization;

var url = "http://localhost:5099/api/Accesos";
JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive=true};
using (var httpdClient = new HttpClient())
{
    var response = await httpdClient.GetAsync(url);
    if (response.IsSuccessStatusCode)
    {
        var conten =await response.Content.ReadAsStringAsync();
        var acceso = JsonSerializer.Deserialize<List<Acceso>>(conten,options);
        foreach(var item in acceso)
        {
            Console.WriteLine(item.codigo_acceso+" "+item.descripcion_acceso);
        }
    }
    else
        Console.WriteLine("Error");
    Console.ReadKey();
}

public class Acceso
{
    public long id_acceso { get; set; }
    public string codigo_acceso { get; set; }
    public string descripcion_acceso { get; set; }
}
