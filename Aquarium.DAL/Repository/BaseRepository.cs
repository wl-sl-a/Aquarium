using System;
using System.Collections.Generic;
using System.Text;

namespace Aquarium.DAL.Repository
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext dbContext;
        protected BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
