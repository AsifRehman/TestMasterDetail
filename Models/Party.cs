using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestMasterDetail.Models
{
    public class tbl_Party
    {
        [Key]
        public int PartyNameId { get; set; }
        public string PartyName { get; set; } = "";
        public int PartyTypeId { get; set; }
    }
}
