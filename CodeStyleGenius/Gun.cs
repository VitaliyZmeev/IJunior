using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gun : MonoBehaviour
{
    [SerializeField] private float _cooldownDuration;
    [SerializeField] private Transform _target;
    [SerializeField] private Bullet _bulletPrefab;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new WaitForSeconds(_cooldownDuration);

        while (enabled)
        {
            Vector3 shootDirection = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bulletPrefab, transform.position + shootDirection, Quaternion.identity);
            bullet.Init(shootDirection);

            yield return wait;
        }
    }
}