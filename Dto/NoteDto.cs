namespace Notes.Api.Dto;

public record NoteDto
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; }= String.Empty;
    public bool IsVisible { get; set; }
}