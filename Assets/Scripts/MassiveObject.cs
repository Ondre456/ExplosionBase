using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MassiveObject : MonoBehaviour
{
    [SerializeField] private float _density = 1;

    private void Awake()
    {
        var rigidbody = GetComponent<Rigidbody>();
        Renderer renderer = rigidbody.GetComponent<Renderer>();
        float volume = transform.localScale.x * transform.localScale.y * transform.localScale.z;
        rigidbody.mass = _density * volume;
    }
}
