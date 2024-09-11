using UnityEngine;

public class Carpet : MonoBehaviour {
    [SerializeField] private UnitPlaces _unitTarget;

    private void OnTriggerEnter( Collider other ) {
        if ( other == null )
            return;

        if ( other.TryGetComponent<Worker>( out Worker unit ) )
            _unitTarget.UnitComeIn( unit );
    }
}
