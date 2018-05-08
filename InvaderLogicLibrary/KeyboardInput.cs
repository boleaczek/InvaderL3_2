using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvaderLogicLibrary
{
    public class KeyboardInput
    {
        private Dictionary<string, bool> keys;

        public KeyboardInput()
        {
            keys = new Dictionary<string, bool>();
        }

        public void update(string key, bool value)
        {
            keys[key] = value;
        }

        public bool isPressed(string key)
        {
            if (!keys.ContainsKey(key))
                return false;

            return keys[key];
        }
    }
}
