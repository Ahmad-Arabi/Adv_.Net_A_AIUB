using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepo<CLASS, ID, RET>
    {
        RET Add(CLASS obj);
        bool Update(CLASS obj);
        List<CLASS> Get();
        CLASS Get(ID id);
        bool Delete(ID id);
    }
}
