namespace ServiceBusEmulatorUI.Shared.Utilities;

public static class RandomUtils
{
    public static bool Flag => Convert.ToBoolean(Random.Shared.Next(0, 2));

    /// <summary>
    /// Returns <see langword="true"/> at a variable rate to help simulate infrequent scenarios.
    /// </summary>
    /// <param name="failValue">The comparative value to fail, if matched. Can be <see langword="null"/> and defaults to <paramref name="max"/>.</param>
    /// <param name="min">The minimum flex value.</param>
    /// <param name="max">The maximum flex value.</param>
    /// <returns><see langword="true"/> if a random number between <paramref name="min"/> and <paramref name="max"/> equals <paramref name="failValue"/>.</returns>
    public static bool FlexibleFlag(int? failValue = null, int min = 1, int max = 10)
    {
        failValue ??= max;

        var value = Random.Shared.Next(min, max);

        return value == failValue;
    }

    /// <summary>
    /// Generates a number in milliseconds and calls <see cref="Task.Delay(int)"/> with it.
    /// </summary>
    /// <param name="min">The minimum milliseconds to delay.</param>
    /// <param name="max">The maximum milliseconds to delay.</param>
    /// <param name="ct">The <see cref="CancellationToken"/> to short circuit the delay.</param>
    public static async Task DelayAsync(int min = 1000, int max = 5000, CancellationToken ct = default)
    {
        var delay = Random.Shared.Next(min, max);

        await Task.Delay(delay, ct);
    }
}
