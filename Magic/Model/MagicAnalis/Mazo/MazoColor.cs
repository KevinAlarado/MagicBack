using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Model.MagicAnalis.Mazo
{
    [Table("MazoColor")]

    public partial class MazoColor
    {
        [Key]
        [Column("Id")]
        public Int16 Id { get; set; }
        [Column("Colores")]
        public string Colores { get; set; }
    }
}
