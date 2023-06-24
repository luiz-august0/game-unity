using UnityEngine;

public class InimigoController : MonoBehaviour
{
    public float velocidade = 2f;
    public float amplitude = 2f;
    private bool foiPuladoEmCima = false;
    private float tempo = 0f;

    private void Update()
    {
        if (!foiPuladoEmCima)
        {
            Movimentar();
        }
    }

    private void Movimentar()
    {
        tempo += Time.deltaTime;
        float movimentoHorizontal = Mathf.Sin(tempo * velocidade) * amplitude;
        Vector2 movimento = new Vector2(movimentoHorizontal, 0);
        transform.Translate(movimento * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("char"))
        {
            // Verifica se o jogador está acima do inimigo
            float alturaDoInimigo = transform.position.y + GetComponent<BoxCollider2D>().bounds.size.y / 2;
            float alturaDoJogador = collision.transform.position.y;
            
            if (alturaDoJogador > alturaDoInimigo)
            {
                foiPuladoEmCima = true;
                DestruirInimigo();
            }
        }
    }

    private void DestruirInimigo()
    {
        // Coloque aqui qualquer ação que deseje executar ao destruir o inimigo
        Destroy(gameObject);
    }
}
