namespace MovieApp.Models.EntityModels
{
    public class Actor
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public int Age { get; set;}      
        public int MovieId { get; set; }   
        public string MovieName { get; set; }  
    }
}