namespace Project.Sequencer {
    public interface IAction {
        public bool KeepRunning { get; }

        public void Execute();
        public void Update();
        public void Reset();
    }
}
