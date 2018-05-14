using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public interface IKeyboardInput
    {
        void Update(string key, bool value);
        bool IsPressed(string key);
    }
}
