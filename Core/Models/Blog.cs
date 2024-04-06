using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Blog
    {
        static int _id;
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        Comment[] comments = Array.Empty<Comment>();


        public Blog(string title, string description)
        {
            Title = title;
            Description = description;
            _id++;
            Id = _id;
        }


        public override string ToString()
        {
            return $"Title: {Title}\nDescription: {Description}";
        }

        public Comment[] GetComment(int commentId)
        {
            Comment[] FilteredComment = new Comment[] { };
            for (int i = 0; i < comments.Length; i++)
            {
                if (comments[i].Id == commentId)
                {
                    Array.Resize(ref FilteredComment, FilteredComment.Length + 1);
                    FilteredComment[FilteredComment.Length - 1] = comments[i];
                }
            }
            return FilteredComment;
        }

        public Comment[] GetAllComments()
        {
            return comments;
        }

        public void AddComment(Comment comment)
        {
            Array.Resize(ref comments, comments.Length + 1);
            comments[comments.Length - 1] = comment;
        }

        public Comment[] RemoveComment(int commentId)
        {
            Comment[] RemoveComment = new Comment[] { };
            for (int i = 0; i < comments.Length; i++)
            {
                if (comments[i].Id != commentId)
                {
                    Array.Resize(ref RemoveComment, RemoveComment.Length + 1);
                    RemoveComment[RemoveComment.Length - 1] = comments[i];
                }
            }
            return comments = RemoveComment;
        }

        public void UpdateComment(int commentId, Comment comment)
        {
            int check = 1;
            for (int i = 0; i < comments.Length; i++)
            {
                if (comments[i].Id == commentId)
                {
                    check = 1;
                    comments[i].Content = comment.Content;
                    Console.WriteLine($"Id: {comments[i].Id}, Content: {comments[i].Content}");
                }
            }
            if (check == 0)
            {
                Console.WriteLine($"id'i {commentId} olan comment yoxdur!");
            }
        }






    }
}
