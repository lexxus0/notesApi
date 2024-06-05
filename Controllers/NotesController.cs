using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Api.Data;
using Notes.Api.Dto;
using Notes.Api.Models.Entities;

namespace Notes.Api.Controllers;

[ApiController]
[Route("api/notes")]
public class NotesController(NotesDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Note>> GetAllNotes()
    {
      return await dbContext.Notes.ToListAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<Note> GetNoteById(int id)
    {
        var note = await dbContext.Notes.FindAsync(id);
        if (note == null)
            return null;
        return note;
    }

    [HttpPost]
    public async Task<int> CreateNote(NoteDto  noteDto)
    {
        var note = new Note
        {
            Title = noteDto.Title,
            Description = noteDto.Description,
            IsVisible = noteDto.IsVisible
        };
        
        await dbContext.Notes.AddAsync(note);
        await dbContext.SaveChangesAsync();

        return note.Id;
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<Note> UpdateNote([FromRoute] int id, [FromBody] Note updatedNote)
    {
        var note = await dbContext.Notes.FindAsync(id);
        if (note == null)
            return null;
        note.Title = updatedNote.Title;
        note.Description = updatedNote.Description;
        note.IsVisible = updatedNote.IsVisible;

        await dbContext.SaveChangesAsync();

        return note;
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<Note> DeleteNote([FromRoute] int id)
    {
        var note = await dbContext.Notes.FindAsync(id);
        if (note == null)
            return null;
        
        dbContext.Notes.Remove(note);
            
        await dbContext.SaveChangesAsync();

        return note;
    }
}