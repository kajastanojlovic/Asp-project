﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Application.DTO
{
    public class UpdateUserAccessDto
    {
        public int UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }
}
