﻿using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DataAccess.IRepository
{
    public interface ICategoryRepository : IBasicRepository<Category>
    {
        void Update(Category category);
    }
}
