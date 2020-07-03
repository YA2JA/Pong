using System;
using UnityEngine;
public class AI : MonoBehaviour
{
    [SerializeField] private float _speed=0f;
    [SerializeField] private GameObject _followedObject = null;
    [SerializeField] [Range(0,2)] private float _missTakeAmplitude, _missTakeMin = 0f;
    private float _missTake;
    private float _targetPosition, _direction, _diffrence;
    private float _move => _speed*_direction*_diffrence*Time.deltaTime;
    private Func<float, float, float> compute = (a, b) => Mathf.Sign(a)*(Mathf.Abs(a)+Mathf.Abs(b));
    private void Update()
    {
        _targetPosition = getTargetPos();
        _direction = Mathf.Sign(_targetPosition-transform.position.y);
        _diffrence = Mathf.Clamp(Mathf.Abs(_targetPosition-this.transform.position.y), 0f, 1f);
        transform.position = new Vector2 (transform.position.x, transform.position.y+_move);   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Ball>() != null){

            _missTake = Mathf.Clamp(_missTakeMin, 0f, _missTakeMin);

        } //*compute(UnityEngine.Random.Range(-_missTakeAmplitude, _missTakeAmplitude),_missTakeMin);
    }
    private float getTargetPos(){

        return _followedObject.transform.position.y+_missTake*Mathf.Sign(-transform.position.y);

    }
}