using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Commands
{
    public static class ValidCommandRunners
    {
        private static readonly List<string> _validWindowsCommandRunners = new() { WindowsCommandPrompt, WindowsTerminal, WindowsPowershell };
        private static readonly List<string> _validMacCommandRunners = new() { MacZsh, UnixBash };
        private static readonly List<string> _validLinuxCommandRunners = new() { UnixBash };

        private static bool _validPreferredWindows(string preferred) => _validWindowsCommandRunners.Contains(preferred);

        // Windows
        private const string WindowsCommandPrompt = "cmd.exe";
        private const string WindowsTerminal = "wt.exe";
        private const string WindowsPowershell = "powershell.exe";

        // Mac
        private const string MacZsh = "zsh";
        private const string MacEnv = "env"; // https://stackoverflow.com/a/58494728/4664094

        // Linux/Shared Unix
        private const string UnixBash = "/bin/bash";

        // Abstracted for future proofing
        // Likely will have a config setting for preferred cmd runner
        // For now just return back default on each machine
        public static string GetCommandRunner(string preferred = "")
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return GetWindowsCommandRunner(preferred);

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return GetLinuxCommandRunner(preferred);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return GetMacOSCommandRunner(preferred);

            throw new InvalidOperationException($"Your platform is not supported or recognised");
        }

        private static string GetWindowsCommandRunner(string preferred = "")
        {
            return WindowsCommandPrompt;
        }

        private static string GetMacOSCommandRunner(string preferred = "")
        {
            return MacEnv;
        }

        private static string GetLinuxCommandRunner(string preferred = "")
        {
            return UnixBash;
        }
    }
}
