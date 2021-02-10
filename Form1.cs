using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using System.Collections.Generic;

namespace MuteMicrophone
{
    public partial class Mainform : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        List<String> recordedKeys = new List<String>();

        string alp = "abcçdefgğhıijklmnoöprsştuüvyzwqx.,<";
        string code = null;
        private IKeyboardMouseEvents m_GlobalHook;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Mainform()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            Transaction.GetMicAsync();
            ControlMute();
            ControlSelectedBtn();
            LoadKeys();
        }

        private void ControlSelectedBtn()
        {
            Console.WriteLine(Properties.Settings.Default.Control);
            if (Properties.Settings.Default.Control)
            {
                rdb_Press.Checked = true;
                rdb_OnOff.Checked = false;
            }
                
            else
            {
                rdb_Press.Checked = false;
                rdb_OnOff.Checked = true;
            }
        }

        private void ControlMute()
        {
            if (Transaction.isMute())
            {
                btn_MuteUnmuteMic.Text = "Unmute";
                pB_MicStatusImage.Image = Properties.Resources.mutemicrophone_80px;
            }

            else
            {
                btn_MuteUnmuteMic.Text = "Mute";
                pB_MicStatusImage.Image = Properties.Resources.microphone_80px;
            }
        }

        private void btn_MuteUnmuteMic_Click(object sender, EventArgs e)
        {
            Transaction.MuteUnMute();
            ControlMute();
        }

        private void rdb_OnOff_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Control = false;
            Properties.Settings.Default.Save();
        }

        private void rdb_Press_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Control = true;
            Properties.Settings.Default.Save();
        }

        private void btn_Record_Click(object sender, EventArgs e)
        {
            lb_Status.Text = "Recording Keys";
            recordedKeys.Clear();
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyDown += Hook_KeyDown;
        }

        private void btn_RecordStop_Click(object sender, EventArgs e)
        {
            lb_Status.Text = "--------";
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyDown -= Hook_KeyDown;
            m_GlobalHook.Dispose();
            SaveKeys();
            if (tb_Keys.Text.Length <= 0)
            {
                lb_Status.Text = "Minimum 1 Key";
            }
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                recordedKeys.Add(e.Button.ToString());
            }
            if (e.Button == MouseButtons.Middle) { e.Handled = true; }
            PrintKeys();
        }

        private void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            code = KeyCodeToUnicode(e.KeyCode);
            if (alp.Contains(code) && code.Length > 0)
                recordedKeys.Add(KeyCodeToUnicode(e.KeyCode));
            else
                recordedKeys.Add(e.KeyCode.ToString());
            e.Handled = true;
            PrintKeys();
        }

        private void PrintKeys()
        {
            tb_Keys.Text = "";
            if (recordedKeys.Count > 0)
            {
                if (recordedKeys.Count > 1)
                {
                    foreach (var item in recordedKeys)
                    {
                        tb_Keys.Text += item;
                        if (recordedKeys[recordedKeys.Count - 1] != item)
                            tb_Keys.Text += " + ";
                    }
                }
                else
                    tb_Keys.Text = recordedKeys[0];
            }
        }

        private void LoadKeys()
        {
            tb_Keys.Text = Properties.Settings.Default.Keys;
        }

        private void SaveKeys()
        {
            Properties.Settings.Default.Keys = "";
            foreach (var item in recordedKeys)
            {
                Properties.Settings.Default.Keys += item;
                if (recordedKeys[recordedKeys.Count - 1] != item)
                    Properties.Settings.Default.Keys += " + ";
            }
            Properties.Settings.Default.Save();
        }

        public string KeyCodeToUnicode(Keys key)
        {
            byte[] keyboardState = new byte[255];
            bool keyboardStateStatus = GetKeyboardState(keyboardState);

            if (!keyboardStateStatus)
            {
                return "";
            }

            uint virtualKeyCode = (uint)key;
            uint scanCode = MapVirtualKey(virtualKeyCode, 0);
            IntPtr inputLocaleIdentifier = GetKeyboardLayout(0);

            StringBuilder result = new StringBuilder();
            ToUnicodeEx(virtualKeyCode, scanCode, keyboardState, result, (int)5, (uint)0, inputLocaleIdentifier);

            return result.ToString();
        }

        [DllImport("user32.dll")]
        static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll")]
        static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags, IntPtr dwhkl);
    }
}
