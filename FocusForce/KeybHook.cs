using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FocusForce
{
    public enum VirtualKeyCode
    {
        LBUTTON = 1,
        RBUTTON = 2,
        CANCEL = 3,
        MBUTTON = 4,
        XBUTTON1 = 5,
        XBUTTON2 = 6,
        BACK = 8,
        TAB = 9,
        CLEAR = 12,
        RETURN = 13,
        SHIFT = 16,
        CONTROL = 17,
        MENU = 18,
        PAUSE = 19,
        CAPITAL = 20,
        KANA = 21,
        HANGEUL = 21,
        HANGUL = 21,
        JUNJA = 23,
        FINAL = 24,
        HANJA = 25,
        KANJI = 25,
        ESCAPE = 27,
        CONVERT = 28,
        NONCONVERT = 29,
        ACCEPT = 30,
        MODECHANGE = 31,
        SPACE = 32,
        PRIOR = 33,
        NEXT = 34,
        END = 35,
        HOME = 36,
        LEFT = 37,
        UP = 38,
        RIGHT = 39,
        DOWN = 40,
        SELECT = 41,
        PRINT = 42,
        EXECUTE = 43,
        SNAPSHOT = 44,
        INSERT = 45,
        DELETE = 46,
        HELP = 47,
        VK_0 = 48,
        VK_1 = 49,
        VK_2 = 50,
        VK_3 = 51,
        VK_4 = 52,
        VK_5 = 53,
        VK_6 = 54,
        VK_7 = 55,
        VK_8 = 56,
        VK_9 = 57,
        VK_A = 65,
        VK_B = 66,
        VK_C = 67,
        VK_D = 68,
        VK_E = 69,
        VK_F = 70,
        VK_G = 71,
        VK_H = 72,
        VK_I = 73,
        VK_J = 74,
        VK_K = 75,
        VK_L = 76,
        VK_M = 77,
        VK_N = 78,
        VK_O = 79,
        VK_P = 80,
        VK_Q = 81,
        VK_R = 82,
        VK_S = 83,
        VK_T = 84,
        VK_U = 85,
        VK_V = 86,
        VK_W = 87,
        VK_X = 88,
        VK_Y = 89,
        VK_Z = 90,
        LWIN = 91,
        RWIN = 92,
        APPS = 93,
        SLEEP = 95,
        NUMPAD0 = 96,
        NUMPAD1 = 97,
        NUMPAD2 = 98,
        NUMPAD3 = 99,
        NUMPAD4 = 100,
        NUMPAD5 = 101,
        NUMPAD6 = 102,
        NUMPAD7 = 103,
        NUMPAD8 = 104,
        NUMPAD9 = 105,
        MULTIPLY = 106,
        ADD = 107,
        SEPARATOR = 108,
        SUBTRACT = 109,
        DECIMAL = 110,
        DIVIDE = 111,
        F1 = 112,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F13 = 124,
        F14 = 125,
        F15 = 126,
        F16 = 127,
        F17 = 128,
        F18 = 129,
        F19 = 130,
        F20 = 131,
        F21 = 132,
        F22 = 133,
        F23 = 134,
        F24 = 135,
        NUMLOCK = 144,
        SCROLL = 145,
        LSHIFT = 160,
        RSHIFT = 161,
        LCONTROL = 162,
        RCONTROL = 163,
        LMENU = 164,
        RMENU = 165,
        BROWSER_BACK = 166,
        BROWSER_FORWARD = 167,
        BROWSER_REFRESH = 168,
        BROWSER_STOP = 169,
        BROWSER_SEARCH = 170,
        BROWSER_FAVORITES = 171,
        BROWSER_HOME = 172,
        VOLUME_MUTE = 173,
        VOLUME_DOWN = 174,
        VOLUME_UP = 175,
        MEDIA_NEXT_TRACK = 176,
        MEDIA_PREV_TRACK = 177,
        MEDIA_STOP = 178,
        MEDIA_PLAY_PAUSE = 179,
        LAUNCH_MAIL = 180,
        LAUNCH_MEDIA_SELECT = 181,
        LAUNCH_APP1 = 182,
        LAUNCH_APP2 = 183,
        OEM_1 = 186,
        OEM_PLUS = 187,
        OEM_COMMA = 188,
        OEM_MINUS = 189,
        OEM_PERIOD = 190,
        OEM_2 = 191,
        OEM_3 = 192,
        OEM_4 = 219,
        OEM_5 = 220,
        OEM_6 = 221,
        OEM_7 = 222,
        OEM_8 = 223,
        OEM_102 = 226,
        PROCESSKEY = 229,
        PACKET = 231,
        ATTN = 246,
        CRSEL = 247,
        EXSEL = 248,
        EREOF = 249,
        PLAY = 250,
        ZOOM = 251,
        NONAME = 252,
        PA1 = 253,
        OEM_CLEAR = 254,
        NUMPAD_RETURN = 1073741837
    }
    class GlobalKeyboardHookEventArgs : HandledEventArgs
        {
            public GlobalKeyboardHook.KeyboardState KeyboardState { get; private set; }
            public GlobalKeyboardHook.LowLevelKeyboardInputEvent KeyboardData { get; private set; }

            public GlobalKeyboardHookEventArgs(
                GlobalKeyboardHook.LowLevelKeyboardInputEvent keyboardData,
                GlobalKeyboardHook.KeyboardState keyboardState)
            {
                KeyboardData = keyboardData;
                KeyboardState = keyboardState;
            }
        }

        //Based on https://gist.github.com/Stasonix
        class GlobalKeyboardHook : IDisposable
        {
            public event EventHandler<GlobalKeyboardHookEventArgs> KeyboardPressed;

            public GlobalKeyboardHook()
            {
                _windowsHookHandle = IntPtr.Zero;
                _user32LibraryHandle = IntPtr.Zero;
                _hookProc = LowLevelKeyboardProc; // we must keep alive _hookProc, because GC is not aware about SetWindowsHookEx behaviour.

                _user32LibraryHandle = LoadLibrary("User32");
                if (_user32LibraryHandle == IntPtr.Zero)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to load library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }



                _windowsHookHandle = SetWindowsHookEx(WH_KEYBOARD_LL, _hookProc, _user32LibraryHandle, 0);
                if (_windowsHookHandle == IntPtr.Zero)
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Failed to adjust keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                }
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    // because we can unhook only in the same thread, not in garbage collector thread
                    if (_windowsHookHandle != IntPtr.Zero)
                    {
                        if (!UnhookWindowsHookEx(_windowsHookHandle))
                        {
                            int errorCode = Marshal.GetLastWin32Error();
                            throw new Win32Exception(errorCode, $"Failed to remove keyboard hooks for '{Process.GetCurrentProcess().ProcessName}'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                        }
                        _windowsHookHandle = IntPtr.Zero;

                        // ReSharper disable once DelegateSubtraction
                        _hookProc -= LowLevelKeyboardProc;
                    }
                }

                if (_user32LibraryHandle != IntPtr.Zero)
                {
                    if (!FreeLibrary(_user32LibraryHandle)) // reduces reference to library by 1.
                    {
                        int errorCode = Marshal.GetLastWin32Error();
                        throw new Win32Exception(errorCode, $"Failed to unload library 'User32.dll'. Error {errorCode}: {new Win32Exception(Marshal.GetLastWin32Error()).Message}.");
                    }
                    _user32LibraryHandle = IntPtr.Zero;
                }
            }

            ~GlobalKeyboardHook()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            private IntPtr _windowsHookHandle;
            private IntPtr _user32LibraryHandle;
            private HookProc _hookProc;

            delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll")]
            private static extern IntPtr LoadLibrary(string lpFileName);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private static extern bool FreeLibrary(IntPtr hModule);

            /// <summary>
            /// The SetWindowsHookEx function installs an application-defined hook procedure into a hook chain.
            /// You would install a hook procedure to monitor the system for certain types of events. These events are
            /// associated either with a specific thread or with all threads in the same desktop as the calling thread.
            /// </summary>
            /// <param name="idHook">hook type</param>
            /// <param name="lpfn">hook procedure</param>
            /// <param name="hMod">handle to application instance</param>
            /// <param name="dwThreadId">thread identifier</param>
            /// <returns>If the function succeeds, the return value is the handle to the hook procedure.</returns>
            [DllImport("USER32", SetLastError = true)]
            static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

            /// <summary>
            /// The UnhookWindowsHookEx function removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
            /// </summary>
            /// <param name="hhk">handle to hook procedure</param>
            /// <returns>If the function succeeds, the return value is true.</returns>
            [DllImport("USER32", SetLastError = true)]
            public static extern bool UnhookWindowsHookEx(IntPtr hHook);

            /// <summary>
            /// The CallNextHookEx function passes the hook information to the next hook procedure in the current hook chain.
            /// A hook procedure can call this function either before or after processing the hook information.
            /// </summary>
            /// <param name="hHook">handle to current hook</param>
            /// <param name="code">hook code passed to hook procedure</param>
            /// <param name="wParam">value passed to hook procedure</param>
            /// <param name="lParam">value passed to hook procedure</param>
            /// <returns>If the function succeeds, the return value is true.</returns>
            [DllImport("USER32", SetLastError = true)]
            static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

            [StructLayout(LayoutKind.Sequential)]
            public struct LowLevelKeyboardInputEvent
            {
                /// <summary>
                /// A virtual-key code. The code must be a value in the range 1 to 254.
                /// </summary>
                public int VirtualCode;

                /// <summary>
                /// A hardware scan code for the key. 
                /// </summary>
                public int HardwareScanCode;

                /// <summary>
                /// The extended-key flag, event-injected Flags, context code, and transition-state flag. This member is specified as follows. An application can use the following values to test the keystroke Flags. Testing LLKHF_INJECTED (bit 4) will tell you whether the event was injected. If it was, then testing LLKHF_LOWER_IL_INJECTED (bit 1) will tell you whether or not the event was injected from a process running at lower integrity level.
                /// </summary>
                public int Flags;

                /// <summary>
                /// The time stamp stamp for this message, equivalent to what GetMessageTime would return for this message.
                /// </summary>
                public int TimeStamp;

                /// <summary>
                /// Additional information associated with the message. 
                /// </summary>
                public IntPtr AdditionalInformation;
            }

            public const int WH_KEYBOARD_LL = 13;
            //const int HC_ACTION = 0;

            public enum KeyboardState
            {
                KeyDown = 0x0100,
                KeyUp = 0x0101,
                SysKeyDown = 0x0104,
                SysKeyUp = 0x0105
            }

            public const int VkSnapshot = 0x2c;
            //const int VkLwin = 0x5b;
            //const int VkRwin = 0x5c;
            //const int VkTab = 0x09;
            //const int VkEscape = 0x18;
            //const int VkControl = 0x11;
            const int KfAltdown = 0x2000;
            public const int LlkhfAltdown = (KfAltdown >> 8);

            public IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
            {
                bool fEatKeyStroke = false;

                var wparamTyped = wParam.ToInt32();
                if (Enum.IsDefined(typeof(KeyboardState), wparamTyped))
                {
                    object o = Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent));
                    LowLevelKeyboardInputEvent p = (LowLevelKeyboardInputEvent)o;

                    var eventArguments = new GlobalKeyboardHookEventArgs(p, (KeyboardState)wparamTyped);

                    EventHandler<GlobalKeyboardHookEventArgs> handler = KeyboardPressed;
                    handler?.Invoke(this, eventArguments);

                    fEatKeyStroke = eventArguments.Handled;
                }

                return fEatKeyStroke ? (IntPtr)1 : CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
            }
        }
    }
