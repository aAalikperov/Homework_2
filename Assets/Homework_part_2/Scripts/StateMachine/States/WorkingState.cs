using UnityEngine;

public class WorkingState : IWorkerState {

    private IWorkerStateSwitcher _switcher;
    private Worker _worker;
    private float _workTimer;

    public WorkingState( IWorkerStateSwitcher switcher, Worker worker) {
        _switcher = switcher;
        _worker = worker;
    }

    public void Enter() {
        Debug.Log( this );
        _workTimer = 0;
    }

    public void Exit() {
    }

    public void Update() {
        _workTimer += Time.deltaTime;

        if ( _workTimer >= _worker.WorkingTime ) {
            _worker.ResetCurrentPlace();
            _worker.SetHomePlace();
            _switcher.SetState<MovingState>();
        }
    }
}
