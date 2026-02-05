using ConfigurationManagementSystem.DbContext;
using ConfigurationManagementSystem.Repositories.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManagementSystem.Repositories;

public class ConfigurationEntitiesRepository
{
    private readonly AppDbContext _context;

    public ConfigurationEntitiesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ConfigurationEntity>> GetAllAsync()
    {
        return await _context.Configurations.ToListAsync();
    }
   
    public async Task<ConfigurationEntity> GetByKeyAsync(string key)
    {
        return await _context.Configurations
            .FirstOrDefaultAsync(x => x.Key.ToLower() == key.ToLower());
    }

    public void Add(ConfigurationEntity entity)
    {
        _context.Configurations.Add(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
