namespace Project.Sequencer.Actions {
    // Base Class for actions only used as blocking event
    public abstract class WaitAction : Action {
        protected WaitAction() : base(WaitType.ENDED) { }
    }
}
