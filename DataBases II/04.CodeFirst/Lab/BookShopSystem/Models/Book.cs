using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Book
    {
        public Book()
        {
            this.Category = new HashSet<Category>();
            this.RelatedBooks = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50), MinLength(1)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }
        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Category> Category { get; set; }

        public ICollection<Book> RelatedBooks { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}