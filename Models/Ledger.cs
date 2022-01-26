using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestMasterDetail.Models
{
    public class tbl_Ledger
    {
        [Key]
        public int Id { get; set; }
        public int VocNo { get; set; }
        public int SrNo { get; set; }
        public DateTime Date { get; set; }
        public string TType { get; set; } = "";
        public int PartyId { get; set; }
        public string? Description { get; set; }
        public Int64? NetDebit { get; set; }
        public Int64? NetCredit { get; set; }
    }
}
