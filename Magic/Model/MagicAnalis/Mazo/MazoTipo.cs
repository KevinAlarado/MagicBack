using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Model.MagicAnalis.Mazo
{
    [Table("MazoTipo")]
    public partial class MazoTipo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Colores")]
        public Int16 Colores { get; set; }
        [Column("Estilo")]
        public Int16 Estilo { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }

    }
}
