using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    public class AnimeRepository : BaseRepository<Anime>
    {

        public override void Save(Anime item)
        {
            if (item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, c => c.ID == item.ID);
            }
        }

    }
}
