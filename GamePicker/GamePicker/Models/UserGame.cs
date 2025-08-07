namespace GamePicker.Models
{
    public class UserGame
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string GameId { get; set; }
        public Game Game { get; set; }
        public UserGame User { get; set; }

        UserGame()
        {

        }
    }
}
