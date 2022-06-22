using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silownia
{
    public class Komentarz
    {
        [Key]
        public int Id { get; set; }
        public string Tresc { get; set; }
        [ForeignKey("Post")]
        public int id_postu { get; set; }
        //public Post Post { get; set; }
    }
}
