namespace ECommerce.Domain.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime? DateCreatedUtc { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModifiedUtc { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
