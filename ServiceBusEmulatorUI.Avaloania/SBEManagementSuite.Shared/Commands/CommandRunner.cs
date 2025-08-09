using CliWrap;
using CliWrap.Buffered;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Commands
{
    internal static class CommandRunner
    {
        internal static async Task ExecuteCommandAndDisregard(string application, string parameters, bool headless = true)
        {
            await ExecuteCommandWithParams(application, parameters, headless);
        }

        internal static async Task<string> ExecuteCommandWithFlatOutput(string application, string parameters, bool headless = true) 
        {
            return await ExecuteCommandWithParams(application, parameters, headless);
        }

        internal static async Task <string[]> ExecuteCommandWithSplitOutput(string application, string parameters, bool headless = true)
        {
            var output = await ExecuteCommandWithParams(application, parameters, headless);

            return output.Split(Environment.NewLine);
        }

        private static async Task<string> ExecuteCommandWithParams(string application, string parameters, bool headless = true)
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo(application, parameters)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    WindowStyle = headless ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal,
                }
            };

            try
            {
                process.Start();

                string stderr = process.StandardError.ReadToEnd();
                string stdOut = await process.StandardOutput.ReadToEndAsync();

                process.WaitForExit();
                process.Close();

                return stdOut;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
