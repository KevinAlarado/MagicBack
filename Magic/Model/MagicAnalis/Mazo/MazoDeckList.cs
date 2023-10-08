using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Magic.Model.MagicAnalis.Mazo
{
    [Table("MazoDeckList")]
    public partial class MazoDeckList
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Mazo")]
        public int Mazo { get; set; }
        [Column("Copias")]
        public Int16 Copias { get; set; }
        [Column("NombreCarta")]
        public string NombreCarta { get; set; }
        [Column("NomEsp")]
        public string NomEsp { get; set; }

    }
}
