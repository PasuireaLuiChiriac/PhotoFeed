namespace a_PhotoFeed.POCO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContestBasic")]
    public partial class ContestBasic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContestBasic()
        {
            PhotoBasicContests = new HashSet<PhotoBasicContest>();
            WinnerBasics = new HashSet<WinnerBasic>();
        }

        [Key]
        public int IdContestBasic { get; set; }

        public int IdCreator { get; set; }

        [Required]
        [StringLength(255)]
        public string ContestName { get; set; }

        [Required]
        public string Description { get; set; }

        public int MaximumPictureNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhotoBasicContest> PhotoBasicContests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WinnerBasic> WinnerBasics { get; set; }
    }
}
