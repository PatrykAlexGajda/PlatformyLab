using System.ComponentModel.DataAnnotations;

namespace Silownia
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public bool CzyBlog { get; set; }
        public string Tresc { get; set; }
        public string Tytul { get; set; }
        public string Zdjecie { get; set; }
        //public List<komentarz> komentarze { get; set; }
    }
}
