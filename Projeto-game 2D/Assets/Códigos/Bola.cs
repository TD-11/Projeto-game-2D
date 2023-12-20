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
        direcao = Random.insideUnitCircle.normalized;
        direcao = new Vector2(direcao.x, 1).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bloquinho"))
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Bloco forte")) 
        {
            collision.gameObject.GetComponent<BlocoForte>().TomouDano();
        }
        if (collision.gameObject.CompareTag("Perigo"))
        {
            
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
        if (collision.contacts.Length == 1)
        {
            direcao = Vector2.Reflect(direcao, collision.contacts[0].normal);
        }
        else
        {
            Vector2 normalMedia = Vector2.zero;
            foreach(var ponto in collision.contacts)
            {
                normalMedia = (normalMedia + ponto.normal) / 2;
            }
            direcao = Vector2.Reflect(direcao, normalMedia);
        }
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = direcao.normalized * velocidade;
    }
}
