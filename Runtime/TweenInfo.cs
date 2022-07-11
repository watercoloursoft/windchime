namespace Windchime.Runtime
{
    public record TweenInfo
    {
        public float Time;
        public EasingSet EasingStyle = Runtime.EasingStyle.Exponential;
        public EasingDirection EasingDirection = EasingDirection.Out;
        public int RepeatCount = 0;
        public bool Reverses = false;
        public float DelayTime = 0;

        public float CycleDuration
        {
            get
            {
                var cycleDuration = DelayTime + Time;
                if (Reverses)
                {
                    cycleDuration += Time;
                }

                return cycleDuration;
            }
        }

        public double GetTweenRatio(float alpha)
        {
            var delay = DelayTime;
            var duration = Time;
            var reverses = Reverses;
            var numCycles = 1 + RepeatCount;
            var easeStyle = EasingStyle;
            var easeDirection = EasingDirection;

            var cycleDuration = CycleDuration;

            if (alpha >= cycleDuration * numCycles)
            {
                return 1;
            }

            var cycleTime = alpha % cycleDuration;
            if (cycleTime <= delay)
            {
                return 0;
            }

            var progress = (cycleTime - delay) / duration;
            if (progress > 1)
            {
                progress = 2 - progress;
            }

            return easeStyle.Get(easeDirection)(progress);
        }
    }
}