using CleanA.Application.TodoLists.Queries.ExportTodos;

namespace CleanA.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
