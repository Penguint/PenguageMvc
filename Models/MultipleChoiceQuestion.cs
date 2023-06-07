namespace PenguageMvc.Models;

public class MultipleChoiceQuestion : Question
{
    public string? Stem { get; set; }
    public string? CorrectAnswer { get; set; }
    public string? Distractor1 { get; set; }
    public string? Distractor2 { get; set; }
    public string? Distractor3 { get; set; }
}
