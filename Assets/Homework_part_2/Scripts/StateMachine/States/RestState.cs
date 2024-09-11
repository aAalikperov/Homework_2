using UnityEngine;

public class RestState : IWorkerState {

    private IWorkerStateSwitcher _switcher;
    private Worker _worker;
    private float _restingTimer;

    public RestState( IWorkerStateSwitcher switcher, Worker worker ) {
        _switcher = switcher;
        _worker = worker;
    }

    public void Enter() {
        Debug.Log( this );
        _restingTimer = 0;
    }

    public void Exit() {
    }

    public void Update() {
        _restingTimer += Time.deltaTime;
        if ( _restingTimer >= _worker.RestTime ) {
            _worker.ResetCurrentPlace();
            _worker.SetMachinePlace();
            _switcher.SetState<MovingState>();
        }
    }
}
