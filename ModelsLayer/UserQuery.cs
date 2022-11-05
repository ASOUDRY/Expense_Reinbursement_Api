using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class UserQuery
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string Name {get; set;} = string.Empty;
        public string Password {get; set;} = string.Empty;
    }
}