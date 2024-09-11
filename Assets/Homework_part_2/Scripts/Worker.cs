using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
[RequireComponent( typeof( Move ) )]
public class Worker : MonoBehaviour {

    [SerializeField] private float _speed;
    [SerializeField] private float _workingTime;
    [SerializeField] private float _restTime;
    [SerializeField] private List<UnitPlaces> _places;

    private UnitPlaces _moveTarget;
    private UnitPlaces _currentPlace;
    private WorkerStateMachine _stateMachine;
    private Move _move;

    public UnitPlaces MoveTarget => _moveTarget;
    public UnitPlaces CurrentPlace => _currentPlace;
    public float Speed => _speed;
    public float WorkingTime => _workingTime;
    public float RestTime => _restTime;
    
    private void Start() {
        _move = GetComponent<Move>();
        SetMachinePlace();
        _stateMachine = new WorkerStateMachine( this );
    }

    private void Update() {
        _stateMachine.Update();
    }

    public void SetHomePlace() => _moveTarget = _places.FirstOrDefault( p => p is Home );
    public void SetMachinePlace() => _moveTarget = _places.FirstOrDefault( p => p is Machine );
    public void AddPlace( UnitPlaces place ) => _places.Add( place );
    public void SetCurrentPlace( UnitPlaces place ) => _currentPlace = place;
    public void ResetCurrentPlace() => _currentPlace = null;
    public void ResetMoveTarget() => _moveTarget = null;
    public void MoveToTarget() => _move.MoveTo( _moveTarget.transform.position, _speed );
    public void StopMoving() => _move.StopMove();
}