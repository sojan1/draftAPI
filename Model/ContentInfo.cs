using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace draftAPI.Model
{
    [Table("ContentInfo")]
    public class ContentInfo
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ContentId { get; set; }
        public string ContentTitle { get; set; }
        public string ContentData { get; set; }
        public string ContentType { get; set; }
        public string ContentCreatedBy { get; set; }
        public string ContentLastUpdatedBy { get; set; }
        public Guid WorkId { get; set; }
    }

}
