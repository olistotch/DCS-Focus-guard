using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocusForce
{
 
    public partial class MainForm : Form
    {
        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_NORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_MAX = 10;

        [DllImport("User32.dll", SetLastError = true)]
        static extern int SetForegroundWindow(IntPtr point);

        [DllImport("User32.dll", SetLastError = true)]
        static extern int GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindowAsync(IntPtr windowHandle, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);


        private GlobalKeyboardHook _globalKeyboardHook;
        private bool _lctrlPressed;
        private bool _lwinPressed;
        private bool _laltPressed;
        private bool _lshiftPressed;
        private bool _rctrlPressed;
        private bool _rwinPressed;
        private bool _raltPressed;
        private bool _rshiftPressed;
        private bool _assignKey;
        private string _keyCombo;
        private bool _appStarted;
        public MainForm()
        {
            InitializeComponent();
            labelStatus.Text = "";
            timerCheck.Interval = 1000;
        }

        private void buttonToggleGuard_Click(object sender, EventArgs e)
        {
            toggleGuard();
        }

        private bool _guardEnabled;

        public bool GuardEnabled
        {
            get { return _guardEnabled; }
            set 
            {
                if (!value)
                {
                    timerCheck.Enabled = true;
                    labelEnabled.Text = "ENABLED";
                    labelEnabled.ForeColor = Color.Green;
                }
                else
                {
                    timerCheck.Enabled = false;
                    labelEnabled.Text = "DISABLED";
                    labelEnabled.ForeColor = Color.Black;
                    labelStatus.Text = "";
                }
                _guardEnabled = value;
            }
        }


        private void toggleGuard()
        {
            GuardEnabled = !GuardEnabled;
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            Process p = Process.GetProcessesByName("DCS").FirstOrDefault();
            if (p != null)
            {
                IntPtr dcs_h = p.MainWindowHandle;
                int textLength = GetWindowTextLength(dcs_h);
                StringBuilder outText = new StringBuilder(textLength + 1);
                int a = GetWindowText(dcs_h, outText, outText.Capacity);
                if ((outText.ToString() == "DCS") || (outText.ToString() == "DCS.openbeta"))
                {
                    labelStatus.Text = "DCS process found. Focus guard enabled.";
                    IntPtr own_h = this.Handle;
                    IntPtr active_h = (IntPtr)GetForegroundWindow();
                    if (active_h != dcs_h)
                    {
                        //Switching first to own window - makes it nore reliable in case of WMR focus - out.
                        ShowWindowAsync(own_h, SW_SHOWDEFAULT);
                        ShowWindowAsync(own_h, SW_SHOW);
                        SetForegroundWindow(own_h);
                        //Back to DCS window
                        ShowWindowAsync(dcs_h, SW_SHOWDEFAULT);
                        ShowWindowAsync(dcs_h, SW_SHOW);
                        SetForegroundWindow(dcs_h);
                        Thread.Sleep(500);
                        //Left-clicking on DCS window - to re-enable controls
                        ClickOnPointTool.ClickOnPoint(dcs_h, new Point(0, 0));
                    }

                }
                else
                {
                    labelStatus.Text = "Found DCS, waiting for the main window...";
                }
            }
            else
            {
                labelStatus.Text = "DCS process is not running.";
            }
        }

        private void buttonAssignCombo_Click(object sender, EventArgs e)
        {
            if (!_assignKey)
            {
                _assignKey = true;
                _keyCombo = labelKeyCombo.Text;
                labelKeyCombo.Text = "Press keys...";
            }
            else 
            {
                _assignKey = false;
                labelKeyCombo.Text = _keyCombo;

            }
        }

        public void SetupKeyboardHooks()
        {
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if ((e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown) || (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown))
            {
                if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.LCONTROL)
                {
                    if (!_lctrlPressed)
                    {
                        _lctrlPressed = true;
                    }
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.LWIN)
                {
                    if (!_lwinPressed)
                    {
                        _lwinPressed = true;
                    }
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.LMENU)
                {
                    if (!_laltPressed)
                    {
                        _laltPressed = true;
                    }
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.RMENU)
                {
                    if (!_raltPressed)
                    {
                        _raltPressed = true;
                    }
                }

                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.LSHIFT)
                {
                    if (!_lshiftPressed)
                    {
                        _lshiftPressed = true;
                    }
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.RCONTROL)
                {
                    if (!_rctrlPressed)
                    {
                        _rctrlPressed = true;
                    }
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.RWIN)
                {
                    if (!_rwinPressed)
                    {
                        _rwinPressed = true;
                    }
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.RSHIFT)
                {
                    if (!_rshiftPressed)
                    {
                        _rshiftPressed = true;
                    }
                }
                else
                {
                    if (_assignKey)
                    {
                        labelKeyCombo.Text = getModifiersList() + KeyConv.VKCToStr((VirtualKeyCode)e.KeyboardData.VirtualCode);
                        _assignKey = false;
                        e.Handled = true;
                    }
                    else
                    {
                        if (labelKeyCombo.Text == getModifiersList() + KeyConv.VKCToStr((VirtualKeyCode)e.KeyboardData.VirtualCode))
                        {
                            toggleGuard();
                            e.Handled = true;
                        }
                    }
                }
            }
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyUp)
            {
                if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.LCONTROL)
                {
                    _lctrlPressed = false;
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.LWIN)
                {
                    _lwinPressed = false;
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.LMENU)
                {
                    _laltPressed = false;
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.RMENU)
                {
                    _raltPressed = false;
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.LSHIFT)
                {
                    _lshiftPressed = false;
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.RCONTROL)
                {
                    _rctrlPressed = false;
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.RWIN)
                {
                    _rwinPressed = false;
                }
                else if (e.KeyboardData.VirtualCode == (int)VirtualKeyCode.RSHIFT)
                {
                    _rshiftPressed = false;
                }

            }
   
        }

        private string getModifiersList()
        {
            string s = "";
            if (_lctrlPressed) s = s + "LCtrl + ";
            if (_lwinPressed) s = s + "LWin + ";
            if (_laltPressed) s = s + "LAlt + ";
            if (_lshiftPressed) s = s + "LShift + ";
            if (_rctrlPressed) s = s + "RCtrl + ";
            if (_rwinPressed) s = s + "RWin + ";
            if (_raltPressed) s = s + "RAlt + ";
            if (_rshiftPressed) s = s + "RShift + ";
            return s;
        }

        public void DisableKeyboardHooks()
        {
            _globalKeyboardHook.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelKeyCombo.Text = Properties.Settings.Default.KeyCombo;
            GuardEnabled = Properties.Settings.Default.GuardEnabled;
            checkBoxStartMinimized.Checked = Properties.Settings.Default.StartMinimized;
            _appStarted = true;
            SetupKeyboardHooks();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show(this,"Do you want to close focus guard?","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
            DisableKeyboardHooks();
            saveSettings();
        }

        private void saveSettings()
        {
            Properties.Settings.Default.GuardEnabled = GuardEnabled;
            Properties.Settings.Default.KeyCombo = labelKeyCombo.Text;
            Properties.Settings.Default.StartMinimized = checkBoxStartMinimized.Checked;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void checkBoxStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (checkBoxStartMinimized.Checked && _appStarted)
            {
                _appStarted = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
