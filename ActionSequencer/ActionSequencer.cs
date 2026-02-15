namespace Project.Sequencer {
    public class ActionSequencer : IAction {
        private IAction[] actions;
        private int currentIndex;
        private bool isRunning;

        public bool IsRunning => isRunning;
        public IAction CurrentAction => actions[currentIndex];

        public bool KeepRunning => !IsRunning;

        public event Action? OnStart;
        public event Action? OnEnd;

        public ActionSequencer(IAction[] actions) {
            this.actions = actions;
        }

        public void Start(int index = 0) {
            if (isRunning)
                throw new Exception("Sequencer already running");

            if (actions.Length == 0)
                return;

            if (index >= actions.Length)
                throw new IndexOutOfRangeException($"Index specified is too high: {index} >= {actions.Length}");

            Reset();
            isRunning = true;
            currentIndex = index;

            OnStart?.Invoke();

            Execute(CurrentAction);
        }

        public void Update() {
            if (!isRunning)
                return;

            CurrentAction.Update();

            while (isRunning && !CurrentAction.KeepRunning) {
                NextAction();
            }
        }

        public void Reset() {
            if (isRunning) {
                End();
            }

            isRunning = false;
            currentIndex = 0;

            for (int i = 0; i < actions.Length; i++) {
                actions[i].Reset();
            }
        }

        public void End() {
            if (!isRunning)
                return;

            isRunning = false;
            OnEnd?.Invoke();
        }

        private void NextAction() {
            ++currentIndex;
            if (currentIndex >= actions.Length) {
                End();
                return;
            }

            Execute(actions[currentIndex]);
        }

        private void Execute(IAction action) {
            action.Execute();
        }

        void IAction.Execute() {
            Start();
        }
    }
}
