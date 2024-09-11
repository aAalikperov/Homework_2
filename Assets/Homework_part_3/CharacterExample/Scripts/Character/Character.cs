using System.Collections;
using UnityEngine;

[RequireComponent( typeof( CharacterController ) )]
public class Character : MonoBehaviour {
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _stamina;
    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _characterController;
    private Coroutine _staminaRecoveryCoroutine = null;

    public CharacterController Controller => _characterController;
    public PlayerInput Input => _input;
    public CharacterConfig Config => _config;
    public CharacterView View => _characterView;
    public float Stamina => _stamina;
    public GroundChecker GroundChecker => _groundChecker;

    private void Awake() {
        _characterView.Initialize();
        _characterController = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine( this );
        SetStamina( _config.DefaultStamina );
    }

    private void Update() {
        _stateMachine.HandleInput();
        _stateMachine.Update();

        if ( _stateMachine.CurrentState is FastRunningState ) {
            if ( _staminaRecoveryCoroutine != null ) {
                StopCoroutine( _staminaRecoveryCoroutine );
                _staminaRecoveryCoroutine = null;
            }
        } else if ( _stamina < _config.DefaultStamina && _staminaRecoveryCoroutine == null ) {
            _staminaRecoveryCoroutine = StartCoroutine( StaminaRecoveryCounter() );
        }
    }

    public void SetStamina( float stamina ) {
        _stamina = stamina;
        if ( _stamina < 0 )
            _stamina = 0;
    }

    private IEnumerator StaminaRecoveryCounter() {
        yield return new WaitForSeconds( _config.StaminaFullRecoverySec );
        SetStamina( _config.DefaultStamina );
        _staminaRecoveryCoroutine = null;
    }

    public bool IfStaminaOnZero() => Stamina <= 0;

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();
}
