using UnityEngine;
public abstract class UnitPlaces : MonoBehaviour {
    public virtual void UnitComeIn( Worker unit ) {
        if ( unit.MoveTarget != this )
            return;

        unit.SetCurrentPlace( this );
    }
}
