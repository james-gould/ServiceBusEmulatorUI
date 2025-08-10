using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Commands.Models
{
    public abstract class StdOutBase<TRepresentation>
    {
        public StdOutBase()
        {
            CommandExecutedTs = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Gets the timestamp the <seealso cref="CommandExecuted"/> was executed was 
        /// </summary>
        public DateTimeOffset CommandExecutedTs { get; private set; }

        /// <summary>
        /// The command that has been executed
        /// </summary>
        public abstract string CommandExecuted { get; }

        /// <summary>
        /// A flag to determine is StdOut is split into a count of parts
        /// </summary>
        public abstract bool ShouldValidateParts { get; }

        /// <summary>
        /// The count of valid parts of StdOut strings which are split into columns
        /// </summary>
        public virtual int ValidPartCount => -1;

        /// <summary>
        /// Validates the part count for a line of StdOut
        /// </summary>
        /// <param name="partCount">The valid amount of parts expected</param>
        /// <returns>Whether or not the part count meets the derived type's requirements</returns>
        public virtual bool HasValidPartCount(int partCount = 0)
        {
            if (!ShouldValidateParts)
                return true;

            // Valid part count has not been overridden, ignore validation
            if (ValidPartCount == -1)
                return true;

            return partCount == ValidPartCount;
        }

        /// <summary>
        /// The mapping method for the commands StdOutput string
        /// </summary>
        /// <param name="stdOut"></param>
        /// <returns></returns>
        public abstract IEnumerable<TRepresentation> MapOutput(string[] stdOut);
   }
}
