﻿namespace BasedCord.Rest
{
    internal class RateLimitBucket
    {
        private ManualResetEventSlim manualResetEvent;

        public RateLimitBucket()
        {
            // Ensure the bucket is being accessed sequentially
            manualResetEvent = new ManualResetEventSlim();
            manualResetEvent.Set();
        }

        public async ValueTask WaitAsync()
        {
            // If rate limit hits 0, we wait for it to unblock.
            manualResetEvent.Wait();
        }

        public async ValueTask SignalDoneAsync(int remaining, float reset_after)
        {
            if (remaining < 1)
            {
                manualResetEvent.Reset();

                _ = Task.Delay((int)(reset_after * 1000)).ContinueWith(async x =>
                {
                    reset();
                });
            }
            else
            {
                reset();
            }
        }

        private void reset()
        {
            // Unlock the manualResetEvent when rate limit resets
            if (!manualResetEvent.IsSet)
            {
                manualResetEvent.Set();
            }
        }
    }
}
