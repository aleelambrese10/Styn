﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styn.Domain.DTOs
{
    public class PreferenceRequestDto
    {
        public int MembresiaId { get; set; }
        public Guid UserId { get; set; }

    }
}
