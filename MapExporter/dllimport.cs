
using System;
using System.Runtime.InteropServices;

namespace MapExporter;

public class HooksImport
{
    // Import user32.dll (containing the function we need) and define
    // the method corresponding to the native function.
    [DllImport("HOOKS-Assembly-CSharp.dll", CharSet = CharSet.Unicode, SetLastError = true)]

    private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

    public static void Main(string[] args)
    {
        // Invoke the function as a regular managed method.
        MessageBox(IntPtr.Zero, "Command-line message box", "Attention!", 0);
    }
}
