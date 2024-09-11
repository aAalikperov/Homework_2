using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeWorkPart2 {

    public class Move : MonoBehaviour {
        private bool _isMoving = false;
        private Vector3 _targetPosition;
        private float _speed = 1f;

        public void MoveTo( Vector3 target, float speed ) {
            _isMoving = true;
            _targetPosition = target;
            _speed = speed;
        }
        public void StopMove() {
            _isMoving = false;
        }

        private void Update() {
            if ( _isMoving == false ) return;

            Vector3 heading = _targetPosition - transform.position;
            Vector3 direction = heading / heading.magnitude;
            direction.y = 0;

            transform.Translate( direction * _speed * Time.deltaTime );
        }
    }

}