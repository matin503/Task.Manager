using Model.Interfaces;
using Model.Model;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Persistence.Repository;

internal class TaskRepository :Repository<TaskModel>, ITaskRepository
{
    private readonly DataProviderContext _context;

    public TaskRepository(DataProviderContext context)
        : base(context)
    {
        _context = context;
    }
}
