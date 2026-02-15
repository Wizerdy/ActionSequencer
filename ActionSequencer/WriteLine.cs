using Timer = System.Timers.Timer;

namespace Project.Sequencer.Actions {
    public class WriteLine : Action {
        private readonly string output;
        private readonly Timer timer;

        private int currentIndex;

        public WriteLine(WaitType waitType, string output, float time = 0f) : base(waitType) {
            this.output = output;
            currentIndex = 0;

            timer = new(time) {
                AutoReset = true
            };

            timer.Elapsed += Timer_Elapsed;
        }

        public override bool IsEnded() => currentIndex >= output.Length;

        public override void Execute() {
            WriteNextChar();
            timer.Start();
        }

        public override void Reset() {
            timer.Stop();
            currentIndex = -1;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e) {
            WriteNextChar();
        }

        private void WriteNextChar() {
            if (IsEnded())
                return;

            ++currentIndex;
            Console.Write(output[currentIndex]);

            if (currentIndex == output.Length - 1) {
                End();
            }
        }

        private void End() {
            timer.Stop();
            Console.WriteLine();
            currentIndex = output.Length;
        }
    }
}
