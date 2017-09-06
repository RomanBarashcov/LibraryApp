using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstracts
{
    public interface IDataRequired<T>
    {
        Task<bool> IsDataRequered(T data);
    }
}
