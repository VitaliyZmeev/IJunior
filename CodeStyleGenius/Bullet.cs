using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.forward = _direction;

        Vector3 targetPosition = transform.position + (_speed * Time.fixedDeltaTime * _direction);
        _rigidbody.MovePosition(targetPosition);
    }

    public void Init(Vector3 direction)
    {
        _direction = direction;
    }
}