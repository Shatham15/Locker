﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lockerSystem.Models
{
    public class tblBuilding
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        [DisplayName("اسم المبنى")]
        public string NameAr { get; set; }
        public string NameEn { get; set; }
       
        public string code { get; set; }
        [DisplayName("رقم المبنى")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]

        public int no { get; set; }

        public string gender { get; set; }
        public ICollection<tblFloor> Floor { get;}


    }
}
