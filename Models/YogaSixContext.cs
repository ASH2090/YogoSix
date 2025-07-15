using Microsoft.EntityFrameworkCore;

namespace YogaSix.Models
{
    public class YogaSixContext : DbContext
    {
        public YogaSixContext(DbContextOptions<YogaSixContext> options) : base(options) { }

        public DbSet<YogaClass> YogaClasses { get; set; } = null!;
        public DbSet<ChallengeLevel> ChallengeLevels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    
    modelBuilder.Entity<ChallengeLevel>().HasData(
        new ChallengeLevel { ChallengeLevelId = "B", Name = "Beginner" },
        new ChallengeLevel { ChallengeLevelId = "I", Name = "Intermediate" },
        new ChallengeLevel { ChallengeLevelId = "A", Name = "Advanced" }
    );

    modelBuilder.Entity<YogaClass>().HasData(
        new YogaClass
        {
            ClassId = 1,
            Name = "Sunrise Flow",
            Size = 20,
            ChallengeLevelId = "B",
            Description = "Gentle morning session"
        },
        new YogaClass
        {
            ClassId = 2,
            Name = "Power Yoga",
            Size = 15,
            ChallengeLevelId = "A",
            Description = "Intense strength-building session"
        }
    );
}
    }
}
