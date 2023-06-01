using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using footty.Models;
using System.Security.Cryptography;
using System.Text;

namespace Footty.Data
{
    public class FoottyContext : DbContext
    {
        public FoottyContext (DbContextOptions<FoottyContext> options)
            : base(options)
        {
        }

        public DbSet<footty.Models.Player> Player { get; set; } = default!;
        public DbSet<footty.Models.Match> Match { get; set; } = default!;
        public DbSet<footty.Models.Stadium> Stadium { get; set; } = default!;
        public DbSet<footty.Models.Team> Team { get; set; } = default!;
        public DbSet<footty.Models.User> User { get; set; } = default!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { 
                    id = 1,
                    username = "admin",
                    password = CalculateMD5Hash("1234"),
                    can_edit = true,
                    token = GenerateToken()
                }
            );
            base.OnModelCreating(modelBuilder);
        }

        public static string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static string GenerateToken()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 24)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
