using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Model.MagicAnalis.Mazo
{
    [Table("Mazo")]
    public partial class Mazo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Tipo")]
        public int Tipo { get; set; }
        [Column("Puesto")]
        public int Puesto { get; set; }
        [Column("Nivel")]
        public short Nivel { get; set; }
        [Column("Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
