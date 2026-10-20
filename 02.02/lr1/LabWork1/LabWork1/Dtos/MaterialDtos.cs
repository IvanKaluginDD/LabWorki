public record MaterialCreateDto(long LessonId, string Title, string Type, string? ContentUrl, string? ContextTetx, int Position = 0);
public record Material