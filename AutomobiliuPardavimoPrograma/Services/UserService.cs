using AutomobiliuPardavimoPrograma.Services;
using AutomobiliuPardavimoPrograma.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomobiliuPardavimoPrograma.Services
{
public class UserService
{
    private readonly AppDbContext _db;

    public UserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Vartotojas>> GautiVisusAsync()
    {
        return await _db.Vartotojai.ToListAsync();
    }

    public async Task<Vartotojas?> GautiPagalIdAsync(int id)
    {
        return await _db.Vartotojai.FindAsync(id);
    }

    public async Task PridetiAsync(Vartotojas auto)
    {
         auto.YraAdmin = false;
        _db.Vartotojai.Add(auto);
        await _db.SaveChangesAsync();
    }

    public async Task AtnaujintiAsync(Vartotojas auto)
    {
        _db.Vartotojai.Update(auto);

        await _db.SaveChangesAsync();
    }

    public async Task IstrintiAsync(int id)
    {
        var auto = await _db.Vartotojai.FindAsync(id);
        if (auto != null)
        {
            _db.Vartotojai.Remove(auto);
            await _db.SaveChangesAsync();
        }
    }
}
}
