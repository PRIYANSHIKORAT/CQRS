﻿namespace CleanArchWithCQRSandMediator.Domain.Entity
{
    public class Blog   
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required string Author { get; set; }

    }
}