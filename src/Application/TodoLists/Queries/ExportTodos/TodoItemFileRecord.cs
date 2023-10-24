using CleanA.Application.Common.Mappings;
using CleanA.Domain.Entities;

namespace CleanA.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
