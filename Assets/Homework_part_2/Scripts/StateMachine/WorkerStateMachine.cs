using System.Collections.Generic;
using System.Linq;

public class WorkerStateMachine: IWorkerStateSwitcher {
    private List<IWorkerState> _states;
    private IWorkerState _currentState;

    public WorkerStateMachine( Worker worker ) {
        _states = new List<IWorkerState>() {
            new RestState(this, worker),
            new WorkingState(this, worker),
            new MovingState(this, worker)
        };

        _currentState = _states[0];
    }

    public void SetState<T>() where T : IWorkerState {

        IWorkerState state = _states.FirstOrDefault( state => state is T );

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
}

