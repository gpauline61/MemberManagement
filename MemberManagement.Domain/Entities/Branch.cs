using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Domain.Entities
{
    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
