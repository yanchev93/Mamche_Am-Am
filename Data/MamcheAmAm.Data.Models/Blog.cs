namespace MamcheAmAm.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MamcheAmAm.Data.Common.Models;

    public class Blog : BaseDeletableModel<string>
    {
        public Blog()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string LinkToYouTube { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
