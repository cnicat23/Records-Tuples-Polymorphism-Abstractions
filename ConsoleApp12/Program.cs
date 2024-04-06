using Core.Models;
using Core;
using System.Reflection.Metadata;
using static System.Formats.Asn1.AsnWriter;

namespace ClassAbstractionsPolymorphismTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title;
            string description;
            string content;
            int id;
            string check;
            do
            {
                Console.WriteLine("1.Blog yarat");
                Console.WriteLine("0. Proqramdan cix.");

                Console.Write("Secim edin: ");
                check = Console.ReadLine();

                switch (check)
                {
                    case "1":
                        do
                        {
                            Console.Write("Title daxil edin: ");
                            title = Console.ReadLine();
                        }
                        while (!title.CheckBlogTitle());

                        do
                        {
                            Console.Write("Description daxil edin: ");
                            description = Console.ReadLine();
                        }
                        while (!description.CheckBlogDescription());

                        Blog blog = new Blog(title, description);

                        do
                        {
                            Console.WriteLine("1. Comment yarat");
                            Console.WriteLine("2. Commentlere bax");
                            Console.WriteLine("3. Commente bax");
                            Console.WriteLine("4. Comment sil");
                            Console.WriteLine("5. Comment deyis");
                            Console.WriteLine("0. Ana menyuya qayit");

                            Console.Write("Secim edin: ");
                            check = Console.ReadLine();
                            switch (check)
                            {

                                case "1":

                                    Console.Write("content daxil edin: ");
                                    content = Console.ReadLine();
                                    Comment comment = new Comment(content);
                                    blog.AddComment(comment);
                                    break;
                                case "2":
                                    if (blog.GetAllComments() == null)
                                    {
                                        Console.WriteLine("Comment yoxdu");
                                    }
                                    else
                                    {
                                        foreach (Comment item in blog.GetAllComments())
                                        {
                                            Console.WriteLine(item);
                                        }
                                    }
                                    break;
                                case "3":
                                    Console.Write("Id daxil edin: ");
                                    id = Convert.ToInt32(Console.ReadLine());
                                    Comment[] commentItem = blog.GetComment(id);
                                    foreach (Comment prod in commentItem)
                                    {
                                        Console.WriteLine(prod);
                                    }
                                    break;
                                case "4":
                                    Console.WriteLine("Id daxil edin: ");
                                    int removeItem = Convert.ToInt32(Console.ReadLine());
                                    foreach (Comment itemRemove in blog.RemoveComment(removeItem))
                                    {
                                        Console.WriteLine(itemRemove);
                                    }
                                    break;
                                case "5":
                                    do
                                    {
                                        Console.Write("Id daxil edin: ");
                                    }
                                    while (!int.TryParse(Console.ReadLine(), out id));
                                    Console.Write("content daxil edin: ");
                                    content = Console.ReadLine();
                                    Comment commentt = new Comment(content);
                                    blog.UpdateComment(id, commentt);
                                    break;
                            }
                        } while (check != "0");
                        break;
                }
            }
            while (check != "0");
        }
    }
}