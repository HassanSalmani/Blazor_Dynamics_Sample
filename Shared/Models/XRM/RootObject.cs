using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Dynamics_Sample.Shared.Models
{
    public class RootObject<T>
    {
        public List<T> Value { get; set; }
    }
}
