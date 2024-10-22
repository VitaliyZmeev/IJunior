using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private bool _isCollidedPlatform;
    private MeshRenderer _meshRenderer;
    private Rigidbody _rigidbody;

    private readonly Color _defaultColor = Color.white;
    private readonly Color _collideColor = Color.red;

    public event UnityAction<Cube> Destroyed;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform _))
        {
            if (_isCollidedPlatform)
            {
                return;
            }

            _isCollidedPlatform = true;
            SetColor(_collideColor);
            StartCoroutine(Destroy());
        }
    }

    public void Init(Vector3 position)
    {
        _isCollidedPlatform = false;
        _rigidbody.velocity = Vector3.zero;

        transform.rotation = Quaternion.identity;
        transform.position = position;
        gameObject.SetActive(true);

        SetColor(_defaultColor);
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(GetLifetime());

        gameObject.SetActive(false);
        Destroyed?.Invoke(this);
    }

    private int GetLifetime()
    {
        int minLifetime = 2;
        int maxLifetime = 5;

        return Random.Range(minLifetime, maxLifetime + 1);
    }

    private void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}