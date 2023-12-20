using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoForte : MonoBehaviour
{
    public int hp = 3;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out renderer);
    }
    public void TomouDano()
    {
        hp--;
        renderer.color *= 1.5f;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

}
