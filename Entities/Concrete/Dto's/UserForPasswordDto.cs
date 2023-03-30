﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Dto_s
{
    public class UserForPasswordDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
