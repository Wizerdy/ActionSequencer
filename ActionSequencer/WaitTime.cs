using Timer = System.Timers.Timer;

namespace Project.Sequencer.Actions {
    internal class WaitTime : WaitAction {
        private readonly Timer timer;

        public WaitTime(float time) : base() {
            timer = new Timer(time) {
                AutoReset = false
            };
        }

        public override void Execute() {
            timer.Start();
        }

        public override bool IsEnded() {
            return !timer.Enabled;
        }

        public override void Reset() {
            timer.Stop();
        }
    }
}
