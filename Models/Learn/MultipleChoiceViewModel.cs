using Microsoft.AspNetCore.Components.Forms;

namespace PenguageMvc.Models.Learn;

public class MultipleChoiceViewModel : QuestionViewModel
{
    public string? Stem { get; set; }
    public List<string>? UserOptions { get; set; }
    public int? UserAnswer { get; set; }
    public int? Truth { get; set; }
    public string? Explaination { get; set; }
}
