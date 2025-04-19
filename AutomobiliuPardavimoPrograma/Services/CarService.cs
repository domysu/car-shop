using AutomobiliuPardavimoPrograma.Services;
using AutomobiliuPardavimoPrograma.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobiliuPardavimoPrograma.Services
{
public class CarService
{
    private readonly AppDbContext _db;

    public CarService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Automobilis>> GautiVisusAsync()
    {
        return await _db.Automobiliai.ToListAsync();
    }

    public async Task<Automobilis?> GautiPagalIdAsync(int id)
    {
        return await _db.Automobiliai.FindAsync(id);
    }

    public async Task PridetiAsync(Automobilis auto)
    {
        _db.Automobiliai.Add(auto);
        await _db.SaveChangesAsync();
    }

    public async Task AtnaujintiAsync(Automobilis auto)
    {
        _db.Automobiliai.Update(auto);
        await _db.SaveChangesAsync();
    }

    public async Task IstrintiAsync(int id)
    {
        var auto = await _db.Automobiliai.FindAsync(id);
        if (auto != null)
        {
            _db.Automobiliai.Remove(auto);
            await _db.SaveChangesAsync();
        }
    }
}
}
