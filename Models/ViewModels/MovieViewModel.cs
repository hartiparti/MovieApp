namespace MovieApp.Models.ViewModels
{
    public class MovieViewModel
    {
     
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Runtime { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        
        public int ActorId { get; set; }
        public string ActorName { get; set; }      
      

   
    }
}