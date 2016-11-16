using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace TCPSerialSample
{
    public class TCPSerialController
    {

        //サーバー名とポート番号
        
        public string Host{get;set;}
        public int Port{get;set;}

        [NonSerialized()]
        private bool isOpen;
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public bool IsOpen {
            get {
                return tcp!=null && tcp.Connected; 
            }
            private set{isOpen=value;}
        }
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public string ReturnCode
        {
            get;
            private set;
        }
        public TCPSerialController()
        {
            this.Host = "";
            this.Port = 2000;
            IsOpen = false;
        }
        [NonSerialized()]
        private TcpClient tcp;
        [NonSerialized()]
        private NetworkStream ns;
        public bool open()
        {
            try
            {
                tcp = new TcpClient(Host, Port);
                ns = tcp.GetStream();//NetworkStreamを取得する
                ns.ReadTimeout = 1000;
            }
            catch (SocketException)
            {
                return false;
            }
            catch
            {
                return false;
            }
            if (tcp != null)
            {
                IsOpen = true;
            }
            return true;
        }
        public void close()
        {
            IsOpen = false;
            tcp.Close();
            //閉じる
            ns.Close();
        }
        public struct CBCmd
        {
            public string cmd;
            public float[] args;
        }
        public CBCmd parse(string cmd)
        {
            CBCmd ret = new CBCmd();
            if (cmd != null)
            {
                if (cmd[0] == '@')
                {
                    ret.cmd = cmd.Substring(1, 2);
                    var args = cmd.Substring(3).TrimEnd().Split(',').Where(x => !string.IsNullOrEmpty(x));
                    // [1] test1@exsample.com;
                    float [] argsf=new float [args.Count()];
                    for (int i = 0; i < args.Count(); i++)
                    {
                        argsf[i]=float.Parse(args.ElementAt(i));
                    }
                    ret.args = argsf;
                }
                else if (cmd[0] == '!')
                {
                    ret.cmd = "!";
                }
                else
                {
                    //unknown
                }
            }
            return ret;
        }
        public bool execCommand(string cmd)
        {
            if (!IsOpen)
            {
                return false;
            }
            //送信
            System.Text.Encoding enc = System.Text.Encoding.UTF8;//文字コードを指定する
            
            byte[] sendBytes = enc.GetBytes(cmd);//文字列をByte型配列に変換
            ns.Write(sendBytes, 0, sendBytes.Length);

            //受信
            MemoryStream ms = new MemoryStream();
            byte[] resBytes = new byte[256];
            int resSize;
            do
            {
                //データの一部を受信する
                try
                {
                    resSize = ns.Read(resBytes, 0, resBytes.Length);
                }
                catch (IOException)
                {
                    MessageBox.Show("サーバーから返答がない。");
                    return false;
                }
                //Readが0を返した時はサーバーが切断したと判断
                if (resSize == 0)
                {
                    MessageBox.Show("サーバーが切断しました。");
                    return false;
                }
                //受信したデータを蓄積する
                ms.Write(resBytes, 0, resSize);
            } while (ns.DataAvailable);
            //受信したデータを文字列に変換
            ReturnCode = enc.GetString(ms.ToArray());
            ms.Close();

            
            return true;
            
        }
    }
    
    
}
