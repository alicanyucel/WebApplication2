namespace WebApplication2.Dtos;

public sealed record UpdateTodoDto(int Id,int UserId,string Title,bool Completed);
