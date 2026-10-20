public record LessonCreateDto(long CourseId, string Title, string Type, int Position = 0);
public record LessonOutDto(long Id, long CourseId, string Title, string Type, int Position);