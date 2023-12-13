using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 direcao;
    public int velocidade = 10;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        direcao = Random.insideUnitCircle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bloquinho"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Perigo"))
        {
            
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }

        direcao = Vector2.Reflect(direcao, collision.contacts[0].normal);
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direcao.normalized * velocidade;
    }
}
