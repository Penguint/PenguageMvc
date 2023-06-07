namespace PenguageMvc.Models;

public class FillInBlankQuestion : Question
{
    public string? StemBeforeBlank { get; set; }
    public string? BlankAnswer { get; set; }
    public string? StemAfterBlank { get; set; }
}
