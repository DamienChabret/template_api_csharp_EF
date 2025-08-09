using System.Text.Json.Serialization;
using api.models;

public class ExampleParam
{
    [JsonPropertyName("idParam")]
    public int idParam { get; set; }

    public bool EqualNull()
    {
        return GroupValue == null && LevelValue == null;
    }
}
