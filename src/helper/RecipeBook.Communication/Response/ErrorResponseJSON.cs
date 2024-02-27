namespace RecipeBook.Communication.Response;

public class ErrorResponseJSON
{
    public List<string> Messages { get; set; }
    public List<string> Errors { get; }

    public ErrorResponseJSON(string message)
    {
        Messages = new List<string>
        {
            message
        };
    }

    public ErrorResponseJSON(List<string> errors)
    {
        Errors = errors;
    }
}
