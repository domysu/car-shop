using AutomobiliuPardavimoPrograma.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AutomobiliuPardavimoPrograma.Services
{
    public class UserService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;  // ← semicolon

        public UserService(IDbContextFactory<AppDbContext> factory)
            => _factory = factory;

        public async Task<List<Vartotojas>> GautiVisusAsync()
        {
            await using var db = _factory.CreateDbContext();
            return await db.Vartotojai.ToListAsync();
        }

        public async Task<Vartotojas?> GautiPagalIdAsync(int id)
        {
            await using var db = _factory.CreateDbContext();
            return await db.Vartotojai.FindAsync(id);
        }

        public async Task<Vartotojas?> GautiPagalUserNameAsync(string username)
        {
            await using var db = _factory.CreateDbContext();
            return await db.Vartotojai
                           .FirstOrDefaultAsync(c => c.Vardas == username);
        }

        public async Task<ServiceResult> PridetiAsync(Vartotojas auto)
        {
            await using var db = _factory.CreateDbContext();

            bool emailExists = await db.Vartotojai
                                       .AnyAsync(c => c.ElPastas == auto.ElPastas);
            if (emailExists)
                return ServiceResult.Fail("Toks el.paštas jau egzistuoja.");

            auto.YraAdmin = false;

            try
            {
                db.Vartotojai.Add(auto);
                await db.SaveChangesAsync();
                return ServiceResult.Success();
            }
            catch (DbUpdateException ex) when (
                ex.InnerException?.Message.Contains("Email jau egzistuoja") == true)
            {
                return ServiceResult.Fail("Toks el. paštas jau egzistuoja (trigger).");
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Klaida registruojant vartotoją: " + ex.Message);
            }
        }

        public async Task AtnaujintiAsync(Vartotojas auto)
        {
            await using var db = _factory.CreateDbContext();
            db.Vartotojai.Update(auto);
            await db.SaveChangesAsync();
        }

        public async Task IstrintiAsync(int id)
        {
            await using var db = _factory.CreateDbContext();
            var auto = await db.Vartotojai.FindAsync(id);
            if (auto != null)
            {
                db.Vartotojai.Remove(auto);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Vartotojas?> AuthenticateAsync(string email, string password)
        {
            await using var db = _factory.CreateDbContext();

            var vartotojas = await db.Vartotojai
                                     .FirstOrDefaultAsync(c => c.ElPastas == email);

            if (vartotojas == null)
                return null;

            var hasher = new PasswordHasher<Vartotojas>();
            var result = hasher.VerifyHashedPassword(
                             vartotojas,
                             vartotojas.SlaptazodisHash,
                             password);

            return result == PasswordVerificationResult.Success
                 ? vartotojas
                 : null;
        }
        public async Task<bool> CheckExistingEmail(string email)
        {
            await using var db = _factory.CreateDbContext();
            var validatingUser = await db.Vartotojai.FirstOrDefaultAsync(c => c.ElPastas == email);
            if (validatingUser != null) 
            {
                return false; // User already exists, returning false;
            }
            return true;
        }   

    }
}
