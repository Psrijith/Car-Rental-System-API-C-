using DEMO__ASS9.Data;
using DEMO__ASS9.Models;

namespace DEMO__ASS9.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }
    }
}
