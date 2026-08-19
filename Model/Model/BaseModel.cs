using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Model;

public abstract class BaseModel
{
    public Guid Id { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreateAt { get; set; }
}
