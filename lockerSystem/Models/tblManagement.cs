﻿namespace lockerSystem.Models
{
    public class tblManagement
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}
