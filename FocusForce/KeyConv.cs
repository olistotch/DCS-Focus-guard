using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusForce
{

    static class KeyConv
    {
        private static short GetSingleCharVirtualKey(char ch)
        {
            switch (ch)
            {
                case '`': return 192;
                case '1': return 49;
                case '2': return 50;
                case '3': return 51;
                case '4': return 52;
                case '5': return 53;
                case '6': return 54;
                case '7': return 55;
                case '8': return 56;
                case '9': return 57;
                case '0': return 48;
                case '-': return 189;
                case '=': return 187;
                case 'q': return 81;
                case 'w': return 87;
                case 'e': return 69;
                case 'r': return 82;
                case 't': return 84;
                case 'y': return 89;
                case 'u': return 85;
                case 'i': return 73;
                case 'o': return 79;
                case 'p': return 80;
                case '[': return 219;
                case ']': return 221;
                case '\\': return 220;

                case 'a': return 65;
                case 's': return 83;
                case 'd': return 68;
                case 'f': return 70;
                case 'g': return 71;
                case 'h': return 72;
                case 'j': return 74;
                case 'k': return 75;
                case 'l': return 76;
                case ';': return 186;
                case '\'': return 222;

                case 'z': return 90;
                case 'x': return 88;
                case 'c': return 67;
                case 'v': return 86;
                case 'b': return 66;
                case 'n': return 78;
                case 'm': return 77;
                case ',': return 188;
                case '.': return 190;
                case '/': return 191;

                default: return 0;

            }
        }

        private static char GetVirtualKeyOfChar(VirtualKeyCode vkk)
        {
            short key = (short)vkk;
            switch (key)
            {
                case 192: return '`';
                case 49: return '1';
                case 50: return '2';
                case 51: return '3';
                case 52: return '4';
                case 53: return '5';
                case 54: return '6';
                case 55: return '7';
                case 56: return '8';
                case 57: return '9';
                case 48: return '0';
                case 189: return '-';
                case 187: return '=';
                case 81: return 'Q';
                case 87: return 'W';
                case 69: return 'E';
                case 82: return 'R';
                case 84: return 'T';
                case 89: return 'Y';
                case 85: return 'U';
                case 73: return 'I';
                case 79: return 'O';
                case 80: return 'P';
                case 219: return '[';
                case 221: return ']';
                case 220: return '\\';

                case 65: return 'A';
                case 83: return 'S';
                case 68: return 'D';
                case 70: return 'F';
                case 71: return 'G';
                case 72: return 'H';
                case 74: return 'J';
                case 75: return 'K';
                case 76: return 'L';
                case 186: return ';';
                case 222: return '\'';

                case 90: return 'Z';
                case 88: return 'X';
                case 67: return 'C';
                case 86: return 'V';
                case 66: return 'B';
                case 78: return 'N';
                case 77: return 'M';
                case 188: return ',';
                case 190: return '.';
                case 191: return '/';
                default: return ' ';
            }
        }

        public static VirtualKeyCode StrToVKC(string strDescr)
        {
            if (strDescr.Length == 1)
            {
                char ch = strDescr.ToLower()[0];
                return (VirtualKeyCode)GetSingleCharVirtualKey(ch);
            }
            else
            {
                switch (strDescr.ToLower())
                {
                    case "lctrl":
                        return VirtualKeyCode.LCONTROL;
                    case "rctrl":
                        return VirtualKeyCode.RCONTROL;
                    case "lalt":
                        return VirtualKeyCode.LMENU;
                    case "ralt":
                        return VirtualKeyCode.RMENU;
                    case "lshift":
                        return VirtualKeyCode.LSHIFT;
                    case "rshift":
                        return VirtualKeyCode.RSHIFT;
                    case "f1":
                        return VirtualKeyCode.F1;
                    case "f2":
                        return VirtualKeyCode.F2;
                    case "f3":
                        return VirtualKeyCode.F3;
                    case "f4":
                        return VirtualKeyCode.F4;
                    case "f5":
                        return VirtualKeyCode.F5;
                    case "f6":
                        return VirtualKeyCode.F6;
                    case "f7":
                        return VirtualKeyCode.F7;
                    case "f8":
                        return VirtualKeyCode.F8;
                    case "f9":
                        return VirtualKeyCode.F9;
                    case "f10":
                        return VirtualKeyCode.F10;
                    case "f11":
                        return VirtualKeyCode.F11;
                    case "f12":
                        return VirtualKeyCode.F12;
                    case "insert":
                        return VirtualKeyCode.INSERT;
                    case "delete":
                        return VirtualKeyCode.DELETE;
                    case "home":
                        return VirtualKeyCode.HOME;
                    case "end":
                        return VirtualKeyCode.END;
                    case "pgup":
                        return VirtualKeyCode.PRIOR;
                    case "pgdn":
                        return VirtualKeyCode.NEXT;
                    case "back":
                        return VirtualKeyCode.BACK;
                    case "tab":
                        return VirtualKeyCode.TAB;
                    case "up":
                        return VirtualKeyCode.UP;
                    case "down":
                        return VirtualKeyCode.DOWN;
                    case "left":
                        return VirtualKeyCode.LEFT;
                    case "right":
                        return VirtualKeyCode.RIGHT;
                    case "enter":
                        return VirtualKeyCode.RETURN;
                    case "esc":
                        return VirtualKeyCode.ESCAPE;
                    case "lwin":
                        return VirtualKeyCode.LWIN;
                    case "rwin":
                        return VirtualKeyCode.RWIN;
                    case "printscr":
                        return VirtualKeyCode.SNAPSHOT;
                    case "scrlock":
                        return VirtualKeyCode.SCROLL;
                    case "pause":
                        return VirtualKeyCode.PAUSE;
                    case "num0":
                        return VirtualKeyCode.NUMPAD0;
                    case "num1":
                        return VirtualKeyCode.NUMPAD1;
                    case "num2":
                        return VirtualKeyCode.NUMPAD2;
                    case "num3":
                        return VirtualKeyCode.NUMPAD3;
                    case "num4":
                        return VirtualKeyCode.NUMPAD4;
                    case "num5":
                        return VirtualKeyCode.NUMPAD5;
                    case "num6":
                        return VirtualKeyCode.NUMPAD6;
                    case "num7":
                        return VirtualKeyCode.NUMPAD7;
                    case "num8":
                        return VirtualKeyCode.NUMPAD8;
                    case "num9":
                        return VirtualKeyCode.NUMPAD9;
                    case "num*":
                        return VirtualKeyCode.MULTIPLY;
                    case "num/":
                        return VirtualKeyCode.DIVIDE;
                    case "numpoint":
                        return VirtualKeyCode.DECIMAL;
                    case "num+":
                        return VirtualKeyCode.ADD;
                    case "num-":
                        return VirtualKeyCode.SUBTRACT;
                    case "space":
                        return VirtualKeyCode.SPACE;
                    case "numlock":
                        return VirtualKeyCode.NUMLOCK;
                    case "capslock":
                        return VirtualKeyCode.CAPITAL;
                    case "plus":
                        return VirtualKeyCode.OEM_PLUS;
                    case "numplus":
                        return VirtualKeyCode.ADD;
                    case "coma":
                        return VirtualKeyCode.OEM_COMMA;
                    case "\\":
                        return VirtualKeyCode.OEM_5;
                    default:
                        return VirtualKeyCode.NONAME;
                }
            }
        }


        public static string VKCToStr(VirtualKeyCode vkc)
        {
            char ch = GetVirtualKeyOfChar(vkc);
            if (ch != ' ') return ch.ToString();
            else
            {
                switch (vkc)
                {

                    case VirtualKeyCode.LCONTROL: return "LCtrl";
                    case VirtualKeyCode.RCONTROL: return "RCtrl";
                    case VirtualKeyCode.LMENU: return "LAlt";
                    case VirtualKeyCode.RMENU: return "RAlt";
                    case VirtualKeyCode.LSHIFT: return "LShift";
                    case VirtualKeyCode.RSHIFT: return "RShift";
                    case VirtualKeyCode.F1: return "F1";
                    case VirtualKeyCode.F2: return "F2";
                    case VirtualKeyCode.F3: return "F3";
                    case VirtualKeyCode.F4: return "F4";
                    case VirtualKeyCode.F5: return "F5";
                    case VirtualKeyCode.F6: return "F6";
                    case VirtualKeyCode.F7: return "F7";
                    case VirtualKeyCode.F8: return "F8";
                    case VirtualKeyCode.F9: return "F9";
                    case VirtualKeyCode.F10: return "F10";
                    case VirtualKeyCode.F11: return "F11";
                    case VirtualKeyCode.F12: return "F12";
                    case VirtualKeyCode.INSERT: return "Insert";
                    case VirtualKeyCode.DELETE: return "Delete";
                    case VirtualKeyCode.HOME: return "Home";
                    case VirtualKeyCode.END: return "End";
                    case VirtualKeyCode.PRIOR: return "PgUp";
                    case VirtualKeyCode.NEXT: return "PgDn";
                    case VirtualKeyCode.BACK: return "Back";
                    case VirtualKeyCode.TAB: return "Tab";
                    case VirtualKeyCode.UP: return "Up";
                    case VirtualKeyCode.DOWN: return "Down";
                    case VirtualKeyCode.LEFT: return "Left";
                    case VirtualKeyCode.RIGHT: return "Right";
                    case VirtualKeyCode.RETURN: return "Enter";
                    case VirtualKeyCode.ESCAPE: return "Esc";
                    case VirtualKeyCode.LWIN: return "LWin";
                    case VirtualKeyCode.RWIN: return "RWin";
                    case VirtualKeyCode.SCROLL: return "ScrLock";
                    case VirtualKeyCode.PAUSE: return "Pause";
                    case VirtualKeyCode.SNAPSHOT: return "PrintScr";

                    case VirtualKeyCode.NUMPAD0: return "Num0";
                    case VirtualKeyCode.NUMPAD1: return "Num1";
                    case VirtualKeyCode.NUMPAD2: return "Num2";
                    case VirtualKeyCode.NUMPAD3: return "Num3";
                    case VirtualKeyCode.NUMPAD4: return "Num4";
                    case VirtualKeyCode.NUMPAD5: return "Num5";
                    case VirtualKeyCode.NUMPAD6: return "Num6";
                    case VirtualKeyCode.NUMPAD7: return "Num7";
                    case VirtualKeyCode.NUMPAD8: return "Num8";
                    case VirtualKeyCode.NUMPAD9: return "Num9";
                    case VirtualKeyCode.MULTIPLY: return "Num*";
                    case VirtualKeyCode.DIVIDE: return "Num/";
                    case VirtualKeyCode.DECIMAL: return "NumPoint";
                    case VirtualKeyCode.ADD: return "Num+";
                    case VirtualKeyCode.SUBTRACT: return "Num-";
                    case VirtualKeyCode.SPACE: return "Space";
                    case VirtualKeyCode.NUMLOCK: return "NumLock";
                    case VirtualKeyCode.CAPITAL: return "CapsLock";
                    case VirtualKeyCode.OEM_PLUS: return "+";
                    case VirtualKeyCode.OEM_COMMA: return ",";
                    case VirtualKeyCode.OEM_5: return "\\";
                    default: return "";

                }
            }

        }
    }
}

