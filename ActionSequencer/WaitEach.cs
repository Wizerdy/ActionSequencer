namespace Project.Sequencer.Actions {
    internal class WaitEach : WaitAction {
        private readonly IAction[] actions;

        private int currentIndex;

        public WaitEach(IAction[] actions) : base() {
            this.actions = actions;
        }

        public override void Execute() {
            for (int i = 0; i < actions.Length; i++) {
                actions[i].Execute();
            }
        }

        public override void Update() {
            for (int i = 0; i < actions.Length; i++) {
                if (actions[i].KeepUpdating) {
                    actions[i].Update();
                }

            }
        }

        public override bool IsEnded() {
            for (int i = 0; i < actions.Length; i++) {
                if (actions[i].KeepWaiting) {
                    return false;
                }
            }

            return true;
        }

        public override void Reset() {
            for (int i = 0; i < actions.Length; i++) {
                actions[i].Reset();
            }
        }
    }
}
