﻿using Ardalis.Result;
using DotNetCleanArch.Core.ProjectAggregate;

namespace DotNetCleanArch.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
