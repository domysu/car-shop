using AutomobiliuPardavimoPrograma.Services;
using AutomobiliuPardavimoPrograma.Models;
using Microsoft.EntityFrameworkCore;


namespace AutomobiliuPardavimoPrograma.Services
{
    public class UserCarLikesService
    {
        private readonly AppDbContext _db;

        public UserCarLikesService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<UserPostLikes>> GautiVisusAsync()
        {
            return await _db.UserPostLikes.ToListAsync();
        }
        public async Task<List<UserPostLikes>> GautiVisusByIdAsync(int Id)
        {
            return await _db.UserPostLikes.Where(c => c.UserId == Id).ToListAsync();
        }
        public async Task<ServiceResult> AddLike(int PostId, int UserId)
        {
            UserPostLikes newLike = new();
            newLike.PostId = PostId;
            newLike.UserId = UserId;

            var existing = await _db.UserPostLikes
            .FirstOrDefaultAsync(x => x.UserId == UserId && x.PostId == PostId);
            if (existing == null)
            {
                _db.UserPostLikes.Add(newLike);
                await _db.SaveChangesAsync();
            }
            else{
                await RemoveLike(existing);
            }


            try
            {
                return ServiceResult.Success();
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Klaida pridedant like: " + ex.Message);
            }

        }

        public async Task<ServiceResult> RemoveLike(UserPostLikes userLike)
        {
            _db.Remove(userLike);
            await _db.SaveChangesAsync();
              try
                {
                return ServiceResult.Success();
                }
                catch (Exception ex)
                {
                return ServiceResult.Fail("Klaida istrinant like: " + ex.Message);
                }

        }
    }
}
