using System.Diagnostics;

namespace Project.Sequencer.Actions {
    public class WriteLine : Action {
        protected readonly string output;
        protected readonly Stopwatch timer;
        protected readonly long delay;
        private readonly (int Left, int Top) cursorDelta;

        protected (int Left, int Top) cursorPosition;
        protected int currentIndex;

        public WriteLine(WaitType waitType, string output, long delay = 0L, (int Left, int Top)? cursorDelta = null) : base(waitType) {
            this.output = output;
            this.delay = delay;
            this.cursorDelta = cursorDelta ?? (0, 0);

            currentIndex = -1;
            timer = new();
        }

        public override bool IsEnded() => output.Length == 0 || currentIndex >= output.Length;

        public override void Execute() {
            cursorPosition = Console.GetCursorPosition();
            cursorPosition.Left += cursorDelta.Left;
            cursorPosition.Top += cursorDelta.Top;

            WriteNextChar();
            timer.Start();
        }

        public override void Update() {
            if (timer.ElapsedMilliseconds < delay)
                return;

            WriteNextChar();
            timer.Restart();
        }

        public override void Reset() {
            timer.Reset();
            currentIndex = -1;
        }

        protected virtual void WriteNextChar() {
            if (IsEnded())
                return;

            ++currentIndex;
            (int Left, int Top) oldCursorPos = Console.GetCursorPosition();

            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);
            Console.Write(output[currentIndex]);

            if (oldCursorPos.Top == cursorPosition.Top) {
                ++oldCursorPos.Top;
            }

            // Temp fix: Automatic scroll on reaching bottom of console window -Coudln't find cleaner fix :'(
            if (oldCursorPos.Top >= Console.BufferHeight) {
                oldCursorPos.Top = Console.BufferHeight - 1;
                --cursorPosition.Top;
                Console.WriteLine();
            }

            ++cursorPosition.Left;
            Console.SetCursorPosition(oldCursorPos.Left, oldCursorPos.Top);

            if (currentIndex == output.Length - 1) {
                End();
            }
        }

        protected void End() {
            timer.Stop();
            currentIndex = output.Length;
        }
    }
}
