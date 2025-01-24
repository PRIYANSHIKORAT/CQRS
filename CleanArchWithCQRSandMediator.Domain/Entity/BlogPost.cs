﻿namespace CleanArchWithCQRSandMediator.Domain.Entity
{
    public class BlogPost
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public required string Author { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? Description { get; set; }
        public string? AuthorUrl { get; set; }
    }
}
