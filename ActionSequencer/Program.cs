using Project.Sequencer;
using Actions = Project.Sequencer.Actions;

namespace Project {
    public static class Program {
        private const float CHAR_TYPE_SPEED = 25f;

        public static int Main(string[] args) {
            ActionSequencer sequencer = new(
                [
                    new Actions.WaitTime(1000f),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "An Action Sequencer is a powerful tool", CHAR_TYPE_SPEED),
                    new Actions.WaitTime(1000f),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Type Continue to continue", CHAR_TYPE_SPEED),
                    new Actions.WaitInput("continue"),
                ]
            );

            sequencer.Start();

            while (sequencer.IsRunning) {
                sequencer.Update();
            }

            return 0;
        }
    }
}
