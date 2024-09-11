using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRunningState : GroundedState {

    private SlowRunningStateConfig _config;
    public SlowRunningState( IStateSwitcher stateSwitcher, StateMachineData data, Character character ) : base( stateSwitcher, data, character ) {
        _config = _character.Config.SlowRunningStateConfig;
    }

    public override void Enter() {
        base.Enter();

        Data.Speed = _config.Speed;

        View.StartRunning();
    }

    public override void Exit() {
        base.Exit();

        View.StopRunning();
    }

    public override void Update() {
        base.Update();

        if ( _character.Stamina > 0 )
            StateSwitcher.SwitchState<RunningState>();

        if ( IsHorizontalInputZero() )
            StateSwitcher.SwitchState<IdlingState>();
    }
}
