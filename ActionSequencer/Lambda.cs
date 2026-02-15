using EventAction = System.Action;

namespace Project.Sequencer.Actions {
    internal class Lambda : Action {
        private readonly EventAction action;

        public Lambda(EventAction action) : base(WaitType.NONE) {
            this.action = action;
        }

        public override void Execute() {
            action?.Invoke(); ;
        }

        public override bool IsEnded() => true;

        public override void Reset() { }
    }
}
