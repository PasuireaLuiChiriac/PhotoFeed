using System;
using System.Collections.Generic;
namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedbackRating")]
    public partial class FeedbackRating
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FeedbackRating()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int IdFeedbackRating { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Usefulness { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

    }
}
