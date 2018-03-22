using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models.InputModels
{
    public class MovieInputModel
    {

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
          
        [Required]
        public int ReleaseYear { get; set; } 
        
        [Required]
        public int Runtime { get; set; }

        [Required]
        public string Genre { get; set; }
        public double Rating { get; set; }      
        public string Image { get; set; }     
        
    } 

}
