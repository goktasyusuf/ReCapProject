namespace Core.Utilities.Results
{
    public interface IResult
    {
        string Message { get; set; }
        bool Success { get; set; }
    }
}
