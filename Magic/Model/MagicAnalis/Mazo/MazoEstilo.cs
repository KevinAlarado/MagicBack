using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Model.MagicAnalis.Mazo
{
    [Table("MazoEstilo")]
    public class MazoEstilo
    {
        [Key]
        [Column("Id")]
        public Int16 Id { get; set; }
        [Column("Descripcion")]
        public string Descripcion { get; set; }
    }
}
