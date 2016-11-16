using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPSerialSample
{
    class CommandParser
    {
        private static Object lockObj = new Object();
        private string buffer = "";
        public delegate void onReturnCmd(string recv);
        public onReturnCmd returnCmd=null;
        private  string cmd = "";
        
        public void read(string data){
            lock(lockObj)
            {
                buffer += data;
            }
            while(GetCmdFromBuffer()){
                if (returnCmd != null)
                {
                    returnCmd(cmd);
                }
            }
        }

        private bool GetCmdFromBuffer()
        {
            lock (lockObj)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[i] == '\n')
                    {
                        cmd=buffer.Substring(0, i + 1);
                        buffer=buffer.Substring(i+1);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
