using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour
{

    private Renderer _renderer;

    public enum Direction
    {
        Vertical, Horizontal
    }

    public float speed;
    public Direction direction;

    private Vector2 offset;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Update()
    {

        if (direction == Direction.Vertical)
        {
            offset.y += speed * Time.deltaTime;
            if (offset.y >= 1)
            {
                offset.y = 0;
            }
        }
        else
        {
            offset.x += speed * Time.deltaTime;
            if (offset.x >= 1)
            {
                offset.x = 0;
            }
        }
        if (_renderer != null)
        {
            _renderer.material.mainTextureOffset = offset;
        }

    }
}
