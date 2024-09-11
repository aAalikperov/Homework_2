using UnityEngine;

public class MovingState : IWorkerState {

    private IWorkerStateSwitcher _switcher;
    private Worker _worker;

    public MovingState( IWorkerStateSwitcher switcher, Worker worker ) {
        _switcher = switcher;
        _worker = worker;
    }

    public void Enter() {
        Debug.Log( this );
        _worker.MoveToTarget();
    }

    public void Exit() {
        _worker.StopMoving();
    }
    public void Update() {
        if ( _worker.CurrentPlace == _worker.MoveTarget ) {
            _worker.ResetMoveTarget();

            if ( _worker.CurrentPlace is Home )
                _switcher.SetState<RestState>();
            else if ( _worker.CurrentPlace is Machine )
                _switcher.SetState<WorkingState>();

        }
    }
}
