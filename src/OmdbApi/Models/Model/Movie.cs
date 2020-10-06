namespace OmdbApi.Models.Model
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; } //  sometimes exist 2001-2006
        public string ImdbID { get; set; }
        public string Type { get; set; }  
        public string Poster { get; set; }
    }
}
