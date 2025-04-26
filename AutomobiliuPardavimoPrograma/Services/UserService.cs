using AutomobiliuPardavimoPrograma.Services;
using AutomobiliuPardavimoPrograma.Models;
using Microsoft.AspNetCore.Identity;
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

        public async Task<ServiceResult> PridetiAsync(Vartotojas auto)
        {

            bool emailExists = await _db.Vartotojai.AnyAsync(c => c.ElPastas == auto.ElPastas);
            if (emailExists)
            {
                return ServiceResult.Fail("Toks el.pastas jau egzistuoja.");
            }
            auto.YraAdmin = false;


            try
            {
                _db.Vartotojai.Add(auto);
                await _db.SaveChangesAsync();
                return ServiceResult.Success();
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("Email jau egzistuoja") == true)
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

        public async Task<Vartotojas> AuthenticateAsync(string email, string password)
        {
                var vartotojas = _db.Vartotojai.FirstOrDefault(c => c.ElPastas == email);
                if(vartotojas == null)
                {
                    return null;
                }
                var hasher = new PasswordHasher<Vartotojas>();
                var result = hasher.VerifyHashedPassword(vartotojas, vartotojas.SlaptazodisHash, password);
                return result == PasswordVerificationResult.Success ? vartotojas : null;
        }
    }
}
