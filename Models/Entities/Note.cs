namespace Notes.Api.Models.Entities;

public record Note
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; }= String.Empty;
    public bool IsVisible { get; set; }
}