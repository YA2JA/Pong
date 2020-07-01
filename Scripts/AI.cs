using UnityEngine;
public class AI : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    [SerializeField] private GameObject _followedObject = null;
    [SerializeField] [Range(0,2)] private float _missTakeAmplitude = 0f;
    private float _missTake;
    private float _targetPosition, _direction, _diffrence;
    private float _move => _speed*_direction*_diffrence*Time.deltaTime;
    private void Update()
    {
        _targetPosition = _followedObject.transform.position.y+_missTake;
        _direction = Mathf.Sign(_targetPosition-this.transform.position.y);
        _diffrence = Mathf.Clamp(Mathf.Abs(_targetPosition-this.transform.position.y), 0f, 1f);
        this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y+_move);   
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.name == "Ball") _missTake = Random.Range(-_missTakeAmplitude, _missTakeAmplitude);
    }
}