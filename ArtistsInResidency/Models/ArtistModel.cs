using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArtistsInResidency.Models
{
    public class ArtistModel
    {
        [Key]
        public int id {get;set;}
        [Required]
        public string fName{get;set;}
        [Required]
        public string lName{get;set;}
        public string alias{get;set;}
        [Required]
        [StringLength(150)]
        public string summary{get;set;}
        public List<ArtModel> associatedWorks {get;set;} 

    }
}