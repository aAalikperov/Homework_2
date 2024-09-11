using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastRunningState : GroundedState {

    private FastRunningStateConfig _config;

    public FastRunningState( IStateSwitcher stateSwitcher, StateMachineData data, Character character ) : base( stateSwitcher, data, character ) {
        _config = character.Config.FastRunningStateConfig;
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

        _character.SetStamina( _character.Stamina - _config.StaminaConsumPerSec * Time.deltaTime );

        if(Input.Movement.FastRun.IsPressed()==false )
            StateSwitcher.SwitchState<RunningState>();

        if ( _character.Stamina <= 0 )
            StateSwitcher.SwitchState<SlowRunningState>();

        if ( IsHorizontalInputZero() )
            StateSwitcher.SwitchState<IdlingState>();
    }

}
