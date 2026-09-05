namespace LuftBornTask.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; } = "System";
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

    }
}