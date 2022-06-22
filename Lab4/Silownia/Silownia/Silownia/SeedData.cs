using Microsoft.EntityFrameworkCore;

/*namespace Silownia
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SilowniaContext
                (serviceProvider.GetRequiredService<DbContextOptions<SilowniaContext>>()))
            {
                if (context.Komentarz.Any())
                {
                    return;
                }

                //context.komentarz.AddRange(new komentarz
                //{
                //    //id_komentarz = 1,
                //    tresc = "abc",

                //});
                context.SaveChanges();
                if (context.Post.Any())
                {
                    return;
                }

                //context.Post.AddRange(new Post
                //{
                //    //id_komentarz = 1,
                //    tresc = "abc",

                //});
                context.SaveChanges();
            }
        }
    }
}*/
