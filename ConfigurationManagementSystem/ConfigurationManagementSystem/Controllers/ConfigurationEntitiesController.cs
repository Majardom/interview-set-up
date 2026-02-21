using ConfigurationManagementSystem.DbContext;
using ConfigurationManagementSystem.Repositories;
using ConfigurationManagementSystem.Repositories.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigurationEntitiesController : ControllerBase
{
    private ConfigurationEntitiesRepository _repository { get; set; }

    public ConfigurationEntitiesController(AppDbContext context)
    {
        _repository = new ConfigurationEntitiesRepository(context);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = _repository.GetAllAsync().Result;
        return Ok(data);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(ConfigurationEntity entity)
    {
        _repository.Add(entity);
        await _repository.SaveChangesAsync();

        return Ok(entity);
    }

    [HttpPost("Update")]
    public  IActionResult Update(ConfigurationEntity entity)
    {
		_repository.SaveChangesAsync();
		return Ok();
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _repository.GetByKeyAsync(id.ToString());

        return Ok();
    }
}
