using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTO;

public abstract record CreateDTO
{
    public Guid Id { get; set; }
}
