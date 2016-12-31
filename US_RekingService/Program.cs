using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace US_RekingService {
    class Program {

        private static void Update() {
            while (true) {
                UInt32[] handles = new UInt32[10];
                Thread.Sleep(10000);

                GetKeyboardLayoutList(10, handles);

                for (int i = 0; i < 10; i++) {
                    if (handles[i] == 0x041d0409) continue;
                    UnloadKeyboardLayout(handles[i]);
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern UInt32 LoadKeyboardLayout(string name, uint flags);

        [DllImport("user32.dll")]
        private static extern void UnloadKeyboardLayout(UInt32 handle);

        [DllImport("user32.dll")]
        private static extern void GetKeyboardLayoutList(uint max, UInt32[] handles);

        static void Main(string[] args) {
             new Thread(new ThreadStart(Update)).Start();
 
        }
    }

}
