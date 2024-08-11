using Microsoft.VisualBasic;
using System.ComponentModel;

namespace lockerSystem.Models
{
    public class tblSemster
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; }
        // year
        [DisplayName("بداية الفصل الدراسي")]
        public DateTime startSemster { get; set; }
        [DisplayName("نهاية الفصل الدراسي")]

        public DateTime endSemster { get; set; }
        [DisplayName(" الفصل الدراسي")]

        public string semsterNameAr { get; set; }
        public string semsterNameEn { get; set; }
        public ICollection<tblSemster> Booking { get; set; }
    }
    }

