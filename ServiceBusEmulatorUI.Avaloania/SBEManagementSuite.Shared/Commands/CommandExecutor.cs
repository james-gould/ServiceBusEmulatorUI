namespace SBEManagementSuite.Shared.Commands
{
    public static class CommandExecutor
    {
        // cached to prevent Runtime.Information lookups - probably better way of doing this.
        private static string _commandRunner = ValidCommandRunners.GetCommandRunner();

        public static async Task<string> DockerExecTest(string command)
        {
            return await CommandRunner.ExecuteCommandWithFlatOutput(_commandRunner, command);
        }
    }
}
