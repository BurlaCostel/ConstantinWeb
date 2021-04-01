using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5
{
    public class SearchService : ISearch
    {
        public string Search(string name)
        {
            return $"Пользуватель {name} найден !";
        }
    }
}
