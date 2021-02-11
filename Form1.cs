using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace MuteMicrophone
{
    public partial class Mainform : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        List<String> recordedKeys = new List<String>();

        List<String> recordedKeysTemp1 = new List<String>();
        List<String> recordedKeysTemp2 = new List<String>();

        System.Drawing.Icon muteIcon = new System.Drawing.Icon(Path.Combine(Application.StartupPath, "MuteMicrophoneMute.ico"));
        System.Drawing.Icon unmuteIcon = new System.Drawing.Icon(Path.Combine(Application.StartupPath, "MuteMicrophone.ico"));

        Thread muteCheckThread = null;

        string alp = "abcçdefgğhıijklmnoöprsştuüvyzwqx.,<";
        string code = null;
        private IKeyboardMouseEvents m_GlobalHook;
        private IKeyboardMouseEvents m_GlobalHookMainListener;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Mainform()
        {
            InitializeComponent();
        }

        private void importLists()
        {
            if (recordedKeysTemp1.Count > 0)
            {
                recordedKeysTemp1.Clear();
            }
            if (recordedKeysTemp2.Count > 0)
            {
                recordedKeysTemp2.Clear();
            }
            if (Properties.Settings.Default.Keys.Contains("+"))
            {
                var array = Properties.Settings.Default.Keys.Split('+', ' ');
                foreach(var item in array)
                {
                    if (item.Length > 0)
                    {
                        recordedKeysTemp1.Add(item);
                        recordedKeysTemp2.Add(item);
                    }
                }
            }
            else
            {
                recordedKeysTemp1.Add(Properties.Settings.Default.Keys);
                recordedKeysTemp2.Add(Properties.Settings.Default.Keys);
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void startMainListener()
        {
            m_GlobalHookMainListener = Hook.GlobalEvents();
            m_GlobalHookMainListener.MouseDownExt += MouseDownEx;
            m_GlobalHookMainListener.MouseUpExt += MouseUpEx;
            m_GlobalHookMainListener.KeyDown += KeyDownF;
            m_GlobalHookMainListener.KeyUp += KeyUpF;
        }

        private void closeMainListener()
        {
            m_GlobalHookMainListener.MouseDownExt -= MouseDownEx;
            m_GlobalHookMainListener.MouseUpExt -= MouseUpEx;
            m_GlobalHookMainListener.KeyDown -= KeyDownF;
            m_GlobalHookMainListener.KeyUp -= KeyUpF;
            m_GlobalHookMainListener.Dispose();
        }

        private void StartThread()
        {
            muteCheckThread = new Thread(t =>
            {
                while (Properties.Settings.Default.Mute)
                {
                    if (!Transaction.isMute())
                    {
                        Transaction.MuteUnMute();
                    }
                    Thread.Sleep(100);
                }
            })
            {IsBackground = true};
            muteCheckThread.Start();
        }

        private void StopThread()
        {
            muteCheckThread.Abort();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            Transaction.GetMicAsync();
            StartThread();
            ControlMute();
            ControlSelectedBtn();
            LoadKeys();
            if (!Properties.Settings.Default.AppState)
                btnAppState_Click(null, null);
            importLists();
            startMainListener();
            checkIcon();
        }

        private void KeyMute(KeyEventArgs e)
        {
            var code = KeyCodeToUnicode(e.KeyCode);
            if (!alp.Contains(code) || code.Length <= 0)
            {
                code = e.KeyCode.ToString();
            }
            if (recordedKeysTemp1.Contains(code) || recordedKeysTemp2.Contains(code))
            {
                if (recordedKeysTemp1.Contains(code))
                {
                    recordedKeysTemp1.Remove(code);
                    if (recordedKeysTemp1.Count <= 0)
                    {
                        Transaction.MuteUnMute();
                        ControlMute();
                        importLists();
                    }
                }
            }
            else
            {
                importLists();
            }
        }

        private void checkIcon()
        {
            if (Transaction.isMute())
            {
                nfI.Icon = muteIcon;
                Icon = muteIcon;
            }

            else
            {
                nfI.Icon = unmuteIcon;
                Icon = unmuteIcon;
            }
                
        }

        private void MouseMute(MouseEventExtArgs e)
        {
            if (recordedKeysTemp1.Contains(e.Button.ToString()) || recordedKeysTemp2.Contains(e.Button.ToString()))
            {
                if (recordedKeysTemp1.Contains(e.Button.ToString()))
                {
                    recordedKeysTemp1.Remove(e.Button.ToString());
                    if (recordedKeysTemp1.Count <= 0)
                    {
                        Transaction.MuteUnMute();
                        ControlMute();
                        importLists();
                        checkIcon();
                    }
                }
            }
            else
            {
                importLists();
            }
        }

        private void MouseDownEx(object sender, MouseEventExtArgs e)
        {
            MouseMute(e);
            if (e.Button == MouseButtons.Middle) { e.Handled = true; }
        }
        private void MouseUpEx(object sender, MouseEventExtArgs e)
        {
            if (Properties.Settings.Default.Control)
                MouseMute(e);
            if (e.Button == MouseButtons.Middle) { e.Handled = true; }
        }
        private void KeyUpF(object sender, KeyEventArgs e)
        {
            if (Properties.Settings.Default.Control)
                KeyMute(e);
        }

        private void KeyDownF(object sender, KeyEventArgs e)
        {
            KeyMute(e);
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
                Properties.Settings.Default.Mute = true;
                StartThread();
            }

            else
            {
                btn_MuteUnmuteMic.Text = "Mute";
                pB_MicStatusImage.Image = Properties.Resources.microphone_80px;
                Properties.Settings.Default.Mute = false;
                StopThread();
            }

            Properties.Settings.Default.Save();
        }

        private void btn_MuteUnmuteMic_Click(object sender, EventArgs e)
        {
            Transaction.MuteUnMute();
            ControlMute();
            checkIcon();
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

        private void StartRecord()
        {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseDownExt += GlobalHookMouseDownExt;
            m_GlobalHook.KeyDown += Hook_KeyDown;
        }

        private void StopRecord()
        {
            m_GlobalHook.MouseDownExt -= GlobalHookMouseDownExt;
            m_GlobalHook.KeyDown -= Hook_KeyDown;
            m_GlobalHook.Dispose();
        }

        private void btn_Record_Click(object sender, EventArgs e)
        {
            lb_Status.Text = "Recording Keys";
            recordedKeys.Clear();
            StartRecord();
            btnAppState.Enabled = false;
        }

        private void btn_RecordStop_Click(object sender, EventArgs e)
        {
            if (tb_Keys.Text.Length <= 0)
                lb_Status.Text = "Minimum 1 Key";
            else
            {
                lb_Status.Text = "--------";
                btnAppState.Enabled = true;
                StopRecord();
                SaveKeys();
                importLists();
            }
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (e.Button != MouseButtons.Left)
                AddRecordedKey(e.Button.ToString());
            if (e.Button == MouseButtons.Middle) { e.Handled = true; }
            PrintKeys();
        }

        private void AddRecordedKey(string code)
        {
            if (!recordedKeys.Contains(code))
                recordedKeys.Add(code);
        }

        private void Hook_KeyDown(object sender, KeyEventArgs e)
        {
            code = KeyCodeToUnicode(e.KeyCode);
            if (alp.Contains(code.ToLower()) && code.Length > 0)
                AddRecordedKey(code.ToLower());  
            else
                AddRecordedKey(e.KeyCode.ToString());
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

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Mainform_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                nfI.ShowBalloonTip(1000,"Mute Microphone","App Still Running", ToolTipIcon.Info);
            }
        }

        private void nfI_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_MinWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseAll()
        {
            btn_MuteUnmuteMic.Enabled = false;
            btn_Record.Enabled = false;
            btn_RecordStop.Enabled = false;
            closeMainListener();
            StopThread();
            btnAppState.Text = "On";
        }

        public void OpenAll()
        {
            btn_MuteUnmuteMic.Enabled = true;
            btn_Record.Enabled = true;
            btn_RecordStop.Enabled = true;
            startMainListener();
            StartThread();
            btnAppState.Text = "Off";
        }

        private void CheckAppState()
        {
            if (Properties.Settings.Default.AppState)
                OpenAll();
            else
                CloseAll();
        }

        private void btnAppState_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AppState)
                Properties.Settings.Default.AppState = false;
            else
                Properties.Settings.Default.AppState = true;

            Properties.Settings.Default.Save();
            CheckAppState();
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AppState)
            {
                btnAppState_Click(null, null);
                StopThread();
            }
            var frm = new About(this);
            frm.ShowDialog();
        }
    }
}
