using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Interactions
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; } //doesn't need to have a logged in user to record interactions

        //how would I record clicks on user profiles and other interactions on the platform?
        public int ArtworkId { get; set; }
        public int ExperiencesId { get; set; }

        [Required]
        public int InteractionType { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}