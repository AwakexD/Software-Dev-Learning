using System;
using System.ComponentModel.DataAnnotations;

namespace Git.Data
{
    public class Commit
    {
        public Commit()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.Now.ToUniversalTime();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }
        public User Creator { get; set; }

        public string ReposotoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
