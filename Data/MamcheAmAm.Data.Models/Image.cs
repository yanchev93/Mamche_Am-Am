namespace MamcheAmAm.Data.Models
{
    using System;

    using MamcheAmAm.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public string Extension { get; set; }

        public string CreatedByUserId { get; set; }

        public ApplicationUser CreatedByUser { get; set; }
    }
}
