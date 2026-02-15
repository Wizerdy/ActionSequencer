namespace Project.Sequencer.Actions {
    public enum WaitType {
        NONE, ENDED
    }

    public abstract class Action : IAction {
        private readonly WaitType waitType;

        public bool KeepWaiting {
            get {
                return waitType switch {
                    WaitType.NONE => false,
                    WaitType.ENDED => !IsEnded(),
                    _ => false,
                };
            }
        }

        public bool KeepUpdating => !IsEnded();

        public Action(WaitType waitType) {
            this.waitType = waitType;
        }

        public abstract void Execute();
        public virtual void Update() { }
        public abstract void Reset();
        public abstract bool IsEnded();
    }
}
