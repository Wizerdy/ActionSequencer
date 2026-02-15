namespace Project.Sequencer {
    public class ActionSequencer : IAction {
        private readonly IAction[] actions;
        private readonly List<IAction> runningActions;

        private int currentIndex;
        private bool isRunning;

        public IAction CurrentAction => actions[currentIndex];

        public bool KeepWaiting => isRunning;
        public bool KeepUpdating => isRunning || runningActions.Count > 0;

        public event Action? OnStart;
        public event Action? OnEnd;

        public ActionSequencer(IAction[] actions) {
            this.actions = actions;
            runningActions = new();
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
            if (!KeepUpdating)
                return;

            for (int i = 0; i < runningActions.Count; i++) {
                runningActions[i].Update();
                if (!runningActions[i].KeepUpdating) {
                    runningActions.RemoveAt(i);
                    --i;
                }
            }

            while (isRunning && !CurrentAction.KeepWaiting) {
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

            if (action.KeepUpdating) {
                runningActions.Add(action);
            }
        }

        void IAction.Execute() {
            Start();
        }
    }
}
