using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model;

public class TaskModel : BaseModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}
