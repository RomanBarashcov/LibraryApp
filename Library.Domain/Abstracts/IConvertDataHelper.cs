using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstracts
{
    public interface IConvertDataHelper<T,U>
    {
        void InitData(List<T> data);
        IEnumerable<U> GetIEnumerubleDbResult();
    }
}
