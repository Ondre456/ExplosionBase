using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetRandomColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        _renderer.material.color = randomColor;
    }

    public void AddRandomForce(float power)
    {
        Vector3 randomDirection = Random.onUnitSphere;
        _rigidbody.AddForce(randomDirection * power, ForceMode.Impulse);
    }
}
