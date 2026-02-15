namespace Project.Sequencer {
    public interface IAction {
        public bool KeepWaiting { get; }
        public bool KeepUpdating { get; }

        public void Execute();
        public void Update();
        public void Reset();
    }
}
