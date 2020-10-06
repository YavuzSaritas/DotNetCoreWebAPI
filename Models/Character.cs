namespace DotNetCoreWebAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligance { get; set; }
        public bool IsDeleted { get; set; }
    }
}