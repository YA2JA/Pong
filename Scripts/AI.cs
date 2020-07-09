using System.Collections;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private GameObject _ball = null;
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] [Range(0,2)] private float _missTakeAmplitude;
    private float _missTake;
    private Vector2 _screenBord;

    #region  Move in right direction
        private float _y => transform.position.y;
        private float _move => _speed*_direction*_diffrence*Time.deltaTime;
        private float _targetPosition => _ball.transform.position.y+_missTake;
        private float _direction => Mathf.Sign(_targetPosition-_y);
        private float _diffrence => Mathf.Clamp(Mathf.Abs(_targetPosition-_y), 0f, 1f);
    #endregion
    #region Does bot need move
        private float _distanceToBall => transform.position.x-_ball.transform.position.x;
        bool _isBallComming => (_ball.GetComponent<Ball>()._direction < 0) ? (_distanceToBall < 0) : (_distanceToBall > 0);

    #endregion

    private void Start() {
        _screenBord = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Ball>() != null) _missTake = Random.Range(0, 1);
    }
    private void LateUpdate(){
        if (_isBallComming)
        transform.position = new Vector2 (transform.position.x, transform.position.y+_move);
        transform.position = new Vector2 (transform.position.x, Mathf.Clamp(transform.position.y, _screenBord.y, -_screenBord.y));
        print(_screenBord.y);
    }
}