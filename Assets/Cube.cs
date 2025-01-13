using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetRandomColor()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        if (_renderer != null)
        {
            _renderer.material.color = randomColor;
        }
        else
        {
            if (_spriteRenderer != null)
                _spriteRenderer.color = randomColor;
        }
    }
}
