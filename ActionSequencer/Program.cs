using Project.Sequencer;
using Actions = Project.Sequencer.Actions;

namespace Project {
    public static class Program {
        private const long CHAR_TYPE_DELAY = 50L;
        private const long LINE_DELAY = 1000L;

        public static int Main(string[] args) {
            Console.CursorVisible = false;

            ActionSequencer sequencer = new(
                [
                    new Actions.WaitTime(2000f),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "An Action Sequencer is a powerful tool", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "It allow to easily edit programs", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Just code reusable actions and 'voilà', modulable code for any purpose", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "It is only limited by a programmer's imagination", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(CHAR_TYPE_DELAY * 20L),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "...", CHAR_TYPE_DELAY * 20L, (48, -1)),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "\n"),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Parrallelism?", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WaitEach([
                        new Actions.WriteLine(Actions.WaitType.ENDED, "You can't- Wait,", CHAR_TYPE_DELAY),
                        new Actions.WriteLine(Actions.WaitType.ENDED, "Of course you can", CHAR_TYPE_DELAY),
                    ]),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "\n"),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "You can choose to wait action to end (what we're doing since the beginning)", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Or just let it be!", CHAR_TYPE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.NONE, " ... Let it be, let it be, let it be, let it be", CHAR_TYPE_DELAY * 10L, (18, -1)),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "\n"),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "You can even nest Action Sequencer!", CHAR_TYPE_DELAY),

                    new ActionSequencer([
                        new Actions.WriteLine(Actions.WaitType.ENDED, "(Like so)", CHAR_TYPE_DELAY),
                        new Actions.WaitTime(LINE_DELAY),
                        new Actions.WriteLine(Actions.WaitType.ENDED, "(We're inside an Action Sequencer, amazing isn't it?)", CHAR_TYPE_DELAY),
                        new Actions.WaitTime(LINE_DELAY),
                        new Actions.WriteLine(Actions.WaitType.ENDED, "(A bit cramped... Let's leave it)", CHAR_TYPE_DELAY),
                        new Actions.WaitTime(LINE_DELAY * 2L),
                        new Actions.WriteLine(Actions.WaitType.ENDED, "\n"),
                        new Actions.WriteLine(Actions.WaitType.ENDED, "Type Continue to continue", CHAR_TYPE_DELAY),
                        new Actions.WaitInput("continue"),
                    ]),

                    new Actions.WriteLine(Actions.WaitType.ENDED, "\n"),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Initially, Action Sequencer are used for Video Games", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Programmers creates Actions for Game designers to edit levels", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "It's better suited with an outside Editor", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "EG: In Unity, you can use the object Hierarchy to visualize and edit an Action Sequencer", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "You can create cinematics with camera movements and everything without an ounce of code!", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "\n"),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "I'm getting sidetracked", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "I did this Gist to showoff basics of an Action Sequencer", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Keep in mind that this one is simple and you can do so much more", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Hope I could teach you (or at least make you remember) some good ol'video games programming", CHAR_TYPE_DELAY),
                    new Actions.WaitTime(LINE_DELAY),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "See ya!", CHAR_TYPE_DELAY),

                    new Actions.WaitTime(LINE_DELAY * 2L),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "\n"),
                    new Actions.WriteLine(Actions.WaitType.ENDED, "Type Amazing to end this long monolog", CHAR_TYPE_DELAY),
                    new Actions.WaitInput("Amazing"),
                ]
            );

            sequencer.Start();

            while (sequencer.KeepUpdating) {
                sequencer.Update();
            }

            return 0;
        }
    }
}
