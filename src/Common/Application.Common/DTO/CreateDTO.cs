using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTO;

public abstract record CreateDTO
{
    public required string Id { get; set; }
}
