using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;

namespace TCPSerialSample
{
    public partial class MainForm : Form
    {
        TCPSerialController controller;
        CommandParser cmdParser=new CommandParser();
        //forjoystick---
        Device joystick;
        bool joystick_exist;
        bool[] JOYBUTTON = new bool[12];
        Int32[] JOYSTICK = new Int32[4];
        Int32 JOYHAT;
        //--------------

        public MainForm()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            System.IO.FileStream fs = new System.IO.FileStream("bj_init.xml", System.IO.FileMode.Open);
            try
            {
                System.Xml.Serialization.XmlSerializer serializer =
            new System.Xml.Serialization.XmlSerializer(typeof(TCPSerialController));

                controller = (TCPSerialController)serializer.Deserialize(fs);

            }
            catch
            {
                controller = new TCPSerialController();
            }
            fs.Close();
            this.Disposed += Form1_Unload;
            ///
            this.textBoxHost.Text = controller.Host;
            this.textBoxPort.Text = controller.Port.ToString();
            //
            this.textBoxTextCmd.KeyDown += this.textCmd_KeyDown;
            //
            //シリアルポート列挙
            string[] ports = SerialPort.GetPortNames();
            comboBoxSerialPort.Items.AddRange(ports);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controller.IsOpen)
            {
                controller.close();
                checkController();
            }

        }
        /// <summary>
        /// 受信時にコールバックされる関数(シリアル)
        /// </summary>
        /// <param name="data">受信データ（送信元情報含む）</param>
        private void receivedSerial(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            
            cmdParser.read(indata);
        }
        // ===========================================================================================
        // JoyStick Initialize========================================================================
        private void InitJoyStick()
        {
            //create joystick device.--------------------------------
            try
            {
                // search for devices
                foreach (DeviceInstance device in Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly))
                {
                    // create the device
                    try
                    {
                        joystick = new Device(device.InstanceGuid);
                    }
                    catch (DirectXException)
                    {
                    }
                }

                if (joystick == null)
                {
                    //Throw exception if joystick not found.
                    throw new Exception("No joystick found.");
                }
                else
                {
                    //listBox2.Items.Add("Success to open Joystick.");
                }

                foreach (DeviceObjectInstance deviceObject in joystick.Objects)
                {
                    if ((deviceObject.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
                        joystick.Properties.SetRange(ParameterHow.ById,
                        deviceObject.ObjectId,
                        new InputRange(-1000, 1000));
                }
                //Set joystick axis mode absolute.
                joystick.Properties.AxisModeAbsolute = true;

                //set cooperative level.
                joystick.SetCooperativeLevel(
                    this,
                    CooperativeLevelFlags.NonExclusive |
                    CooperativeLevelFlags.Background);

                // acquire the device
                joystick.Acquire();
                joystick_exist = true;
            }
            catch
            {
                joystick_exist = false;
                //listBox2.Items.Add("Fail to open Joystick.");
            }

            //create joystick device end.--------------------------------

        }



        private void buttonSend_Click(object sender, EventArgs e)
        {
            string cmd = textBoxTextCmd.Text;
            sendMessage(cmd);
            
        }
        private void checkController()
        {
            if (controller.IsOpen)
            {
                this.textBox1.Text = "状態：Open";
                this.buttonConnect.Text = "切断";
            }else{
                this.textBox1.Text = "状態：Close";
                this.buttonConnect.Text = "接続";
            }
        }
        private delegate void delegateRecvMessage(string ret);
        void recvMessage(string ret)
        {
            if (textBoxLog.InvokeRequired)
            {
                //メインスレッド以外から呼び出されたので、メインスレッドで呼びなおす
                this.Invoke(new delegateRecvMessage(recvMessage), new object[] {ret });
            }
            else
            {
                this.textBoxLog.Text += ret + "\r\n";
                TCPSerialController.CBCmd c = controller.parse(ret);
                
                //this.textBoxLog.AppendText(bjController.ReturnCode + "\r\n");
                //カレット位置を末尾に移動
                //textBoxLog.Focus();
                textBoxLog.SelectionStart = textBoxLog.Text.Length;
                textBoxLog.ScrollToCaret();
            }
        }
        private void sendMessage(string cmd)
        {
            if (controller.IsOpen)
            {
                this.textBoxLog.Text += cmd + "\r\n";
                controller.execCommand(cmd + "\n");
                recvMessage(controller.ReturnCode);
            }
            else if (serialPort.IsOpen)
            {
                this.textBoxLog.Text += cmd + "\r\n";
                cmdParser.returnCmd = (string ret) =>
                {
                    recvMessage(ret);
                };
                serialPort.Write(cmd + "\n");
                
            }
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            controller.Host = this.textBoxHost.Text;
            if (controller.IsOpen)
            {
                controller.close();
                checkController();
            }else{
                try
                {
                    controller.Port = int.Parse(this.textBoxPort.Text);
                }catch(FormatException){
                    return;
                }
                controller.open();
                checkController();
            }
        }


        private void textCmd_KeyDown(Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.buttonSend.PerformClick();
            }
        }
        private void Form1_Unload(object sender, EventArgs e)
        {
            System.Xml.Serialization.XmlSerializer serializer =
        new System.Xml.Serialization.XmlSerializer(typeof(TCPSerialController));
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream("bj_init.xml", System.IO.FileMode.Create);
                serializer.Serialize(fs, controller);
                fs.Close();
            }
            catch
            {
                return;
            }
            
        }
        private void timerStatus_Tick(object sender, EventArgs e)
        {
            checkController();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!joystick_exist)
                {
                    InitJoyStick();//===JoyStick Check ============================================
                }
                else
                {
                    joystick_exist = false;
                }
            }
            else
            {
                joystick_exist = false;
            }
        }

        private void Joystick_timer_Tick(object sender, EventArgs e)
        {
            if (joystick_exist)
            {
                try
                {
                    //Get Mouse State.
                    
                    //Get
                    JoystickState state = joystick.CurrentJoystickState;

                    byte[] buttons = state.GetButtons();
                    int[] pov = state.GetPointOfView();

                    //Output

                    int joy_x = state.X ;
                    int joy_y = -state.Y;
                    int joy_z = state.Z;
                    int joy_rz = -state.Rz;
                    //buttons[0] !=0;
                    //buttons[1] != 0;
                    //buttons[2] != 0;
                    //buttons[3] != 0;
                    //buttons[4] != 0;
                    bool btn_6 = buttons[5]!=0;
                    //buttons[6] != 0;
                    //buttons[7] != 0;
                    //buttons[8] != 0;
                    //buttons[9] != 0;
                    //buttons[10] != 0;
                    //buttons[11] != 0;
                    //pov[0];
                    //                    listBox2.Items.Add("X:"+joy_x.ToString()+"Y:"+joy_y.ToString()+"Z:"+joy_z.ToString()+"RZ:"+joy_rz.ToString());

                    int deadband = 120;
                    double gain = 127.0/1000;
                    if (btn_6)
                    {
                        gain *=2;//high speed
                    }
                    else
                    {
                        gain *= 1;//high speed
                    }
                    if ((-deadband < joy_y) && (joy_y < deadband)) joy_y = 0;
                    if (joy_y < 0) joy_y = joy_y + deadband;
                    if (joy_y > 0) joy_y = joy_y - deadband;
                    if ((-deadband < joy_z) && (joy_z < deadband)) joy_z = 0;
                    if (joy_z < 0) joy_z = joy_z + deadband;
                    if (joy_z > 0) joy_z = joy_z - deadband;
                    
                }
                catch
                {
                    joystick_exist = false;
                    checkBox1.Checked = false;
                    //listBox2.Items.Add("Fail to Read Joystick.");
                    return;
                }
            }
        }


        private void buttonPortOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                serialPort.PortName = (string)comboBoxSerialPort.SelectedItem;
                serialPort.BaudRate = int.Parse(textBoxBaud.Text);
                //
                // text
                serialPort.DataReceived += new SerialDataReceivedEventHandler(receivedSerial);
                
                serialPort.Open();
            }
            catch
            {
                MessageBox.Show("シリアルポートがオープンできませんでした");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void timerStatusCheck_Tick(object sender, EventArgs e)
        {
            
            //シリアルの状態を確認する。
            if (serialPort.IsOpen)
            {
                labelSerialStatus.Text = "状態：Open";
            }
            else
            {
                labelSerialStatus.Text = "状態：Close";
            }
        }

        private void buttonLogClear_Click(object sender, EventArgs e)
        {
            textBoxLog.Clear();
        }





    }
}
