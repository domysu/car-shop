using AutomobiliuPardavimoPrograma.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace AutomobiliuPardavimoPrograma.Services
{
    public class UserService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        private readonly ILogger<UserService> _logger;

        public UserService(IDbContextFactory<AppDbContext> factory, ILogger<UserService> logger)
        {
            _factory = factory;
            _logger = logger;
        }

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

        public async Task<ServiceResult> PridetiAsync(Vartotojas user)
        {
            await using var db = _factory.CreateDbContext();

            try
            {
                // Check for existing email
                bool emailExists = await db.Vartotojai
                    .AnyAsync(c => c.ElPastas == user.ElPastas);
                
                if (emailExists)
                    return ServiceResult.Fail("Email already exists");

                // Generate a random salt
                byte[] salt = new byte[16];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                user.Salt = Convert.ToBase64String(salt);

                // Hash password with salt
                var hasher = new PasswordHasher<Vartotojas>();
                user.SlaptazodisHash = hasher.HashPassword(user, user.RawPassword + user.Salt);
                
                user.YraAdmin = false;

                db.Vartotojai.Add(user);
                await db.SaveChangesAsync();

                _logger.LogInformation("New user registered: {Username}", user.Vardas);
                
                return ServiceResult.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering user: {Username}", user.Vardas);
                return ServiceResult.Fail($"Registration error: {ex.Message}");
            }
        }

        public async Task AtnaujintiAsync(Vartotojas user)
        {
            await using var db = _factory.CreateDbContext();
            try
            {
                db.Vartotojai.Update(user);
                await db.SaveChangesAsync();
                _logger.LogInformation("User updated: {Username}", user.Vardas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user: {Username}", user.Vardas);
                throw;
            }
        }

        public async Task IstrintiAsync(int id)
        {
            await using var db = _factory.CreateDbContext();
            var user = await db.Vartotojai.FindAsync(id);
            if (user != null)
            {
                try
                {
                    db.Vartotojai.Remove(user);
                    await db.SaveChangesAsync();
                    _logger.LogInformation("User deleted: {Username}", user.Vardas);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error deleting user: {Username}", user.Vardas);
                    throw;
                }
            }
        }

        public async Task<Vartotojas?> AuthenticateAsync(string email, string password)
        {
            await using var db = _factory.CreateDbContext();

            try
            {
                var user = await db.Vartotojai
                    .FirstOrDefaultAsync(c => c.ElPastas == email);

                if (user == null)
                {
                    _logger.LogWarning("Failed login attempt for non-existent email: {Email}", email);
                    return null;
                }

                var hasher = new PasswordHasher<Vartotojas>();
                var result = hasher.VerifyHashedPassword(
                    user,
                    user.SlaptazodisHash,
                    password + user.Salt);

                if (result == PasswordVerificationResult.Success)
                {
                    _logger.LogInformation("Successful login: {Username}", user.Vardas);
                    return user;
                }

                _logger.LogWarning("Failed login attempt for user: {Username}", user.Vardas);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during authentication for email: {Email}", email);
                return null;
            }
        }

        public async Task<bool> CheckExistingEmail(string email)
        {
            await using var db = _factory.CreateDbContext();
            try
            {
                var existingUser = await db.Vartotojai
                    .FirstOrDefaultAsync(c => c.ElPastas == email);
                return existingUser == null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking email existence: {Email}", email);
                throw;
            }
        }
    }
}