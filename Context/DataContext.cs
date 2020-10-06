using DotNetCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option):base(option){  }
        public DbSet<Character> Character { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterSkill>().HasKey(cs=>new {cs.CharacterId,cs.SkillId});
        }
    }
}