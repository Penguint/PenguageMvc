namespace PenguageMvc.Models;

public abstract class Question
{
    public int Id { get; set; }
    public string? Language { get; set; }
    public string? Explanation { get; set; }
}
