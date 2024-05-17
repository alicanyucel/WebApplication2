namespace WebApplication2.Models
{
    public sealed class Todo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }=string.Empty;
        public bool Completed { get; set; }
    }
}
