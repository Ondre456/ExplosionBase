using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void AcceptForce(Vector3 power)
    {
        _rigidbody.AddForce(power, ForceMode.Impulse);
    }
}
