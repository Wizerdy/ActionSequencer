namespace Project.Sequencer.Actions {
    public class WaitInput : WaitAction {
        private string? targetInput;

        public WaitInput(string? targetInput = null) : base() {
            this.targetInput = targetInput;
        }

        public override void Execute() {
            string? input;
            do {
                input = Console.ReadLine();
            } while (targetInput != null && input?.ToLower() != targetInput?.ToLower());
        }

        // ReadKey is already a blocking function
        public override bool IsEnded() => true;

        public override void Reset() { }
    }
}
