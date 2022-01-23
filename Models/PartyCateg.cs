using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMasterDetail.Models
{
    [Table("tbl_PartyCateg")]
    public class tbl_PartyCateg
    {
        [Key]
        public int PartyCategId { get; set; }
        public string PartyCateg { get; set; } = "";
        public short HeadId { get; set; }
    }
}
