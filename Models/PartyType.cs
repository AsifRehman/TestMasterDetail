using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestMasterDetail.Models
{
    [Table("tbl_PartyType")]
    public class tbl_PartyType
    {
        [Key]
        public int PartyTypeId { get; set; }
        public string PartyType { get; set; } = "";
        public int PartyCategId { get; set; }
        public List<tbl_Party> Parties { get; set; } = new List<tbl_Party>();

    }
}
