namespace ConfigurationManagementSystem.Repositories.Dtos;

public class ConfigurationEntity
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public bool IsActive { get; set; }
}
