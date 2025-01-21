using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Explosion : MonoBehaviour
{
    private float _power;
    private float _distance;
    private float _duration;
    private float _currentRadius;
    private SphereCollider _collider;

    private void Awake()
    {
        _currentRadius = 0;
        _collider = gameObject.GetComponent<SphereCollider>();
    }

    private void FixedUpdate()
    {
        if (_currentRadius < _distance)
        {
            _currentRadius = Mathf.Lerp(0f, _distance, Time.time / _duration);
            _collider.radius = _currentRadius;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody = other.GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            rigidbody.AddForce((direction * _power) / _currentRadius, ForceMode.Impulse);
        }
    }

    public void AcceptExplosionCharacteristics(float mass, float powerModifier)
    {
        const int DistanceMultiplier = 5;

        _power = powerModifier * mass;
        _distance = _power * DistanceMultiplier;
    }
}
