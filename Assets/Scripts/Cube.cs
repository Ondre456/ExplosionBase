using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ExplosionSource))]
public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private ExplosionSource _explosionSource;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _explosionSource = GetComponent<ExplosionSource>();
    }

    public void AcceptForce(Vector3 power)
    {
        _rigidbody.AddForce(power, ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        var eplosionProducts = _explosionSource.Explode();
        
        foreach (var product in eplosionProducts)
        {
            Cube cube = product.AddComponent<Cube>();
            cube.AcceptForce(_explosionSource.GetExplosionPower());
        }
    }
}
