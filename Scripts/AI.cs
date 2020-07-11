using UnityEngine;
public class AI : BordLimmit
{
    [SerializeField] private GameObject _ball = null;
    [SerializeField] private float _speed = 1f;
    [SerializeField] [Range(0,2)] private float _missTakeAmplitude = 0f;
    private float _missTake;
    #region  Move in right direction
        private float _y => transform.position.y;
        private float _move => _speed*_direction*_diffrence*Time.deltaTime;
        private float _targetPosition => _ball.transform.position.y+_missTake;
        private float _direction => Mathf.Sign(_targetPosition-_y);
        private float _diffrence => Mathf.Clamp(Mathf.Abs(_targetPosition-_y), 0f, 1f);
    #endregion
    #region Does bot need move
        private float _distanceToBall => transform.position.x-_ball.transform.position.x;
        private bool _isBallComming => (_ball.GetComponent<Ball>()._direction < 0) ? (_distanceToBall < 0) : (_distanceToBall > 0);
    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Ball>() != null) _missTake = Random.Range( - _missTakeAmplitude, _missTakeAmplitude);
    }
    private void FixedUpdate(){
        if (_isBallComming) transform.position = new Vector2 (transform.position.x, transform.position.y+_move);
    }

}