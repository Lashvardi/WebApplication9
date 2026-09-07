namespace WebApplication9.Requests;

public class UpdateCourse
{
    public int Id { get; set; }
    public string newTitle { get; set; }
    public decimal newPrice { get; set; }
}