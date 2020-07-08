using System.Collections;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float _speed = 0f;
    [SerializeField] private GameObject _ball = null;
    [SerializeField] [Range(0,2)] private float _missTakeAmplitude = 0f;
    private float _missTake;
    private float _move => _speed*_direction*_diffrence*Time.deltaTime;
    private float _y => transform.position.y;
    float _targetPosition => _ball.transform.position.y+_missTake;
    float _direction => Mathf.Sign(_targetPosition-_y);
    float _diffrence => Mathf.Clamp(Mathf.Abs(_targetPosition-_y), 0f, 1f);
    bool IsBallComming => (_ball.GetComponent<Ball>()._direction < 0) ? (transform.position.x-_ball.transform.position.x < 0) : (transform.position.x-_ball.transform.position.x > 0);
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Ball>() != null) _missTake = Random.Range(0, _missTakeAmplitude);
    }

    private void FixedUpdate() {
        if (IsBallComming){
            transform.position = new Vector2 (transform.position.x, _y+_move);   
        }
    }
}