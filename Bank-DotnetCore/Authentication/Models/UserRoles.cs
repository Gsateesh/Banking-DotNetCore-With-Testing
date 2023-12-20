using System.Text.Json.Serialization;

namespace Bank_DotnetCore.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserRoles
    {
        Admin = 0,
        Manager = 1,
        Cusstomer = 2,
    }
}
