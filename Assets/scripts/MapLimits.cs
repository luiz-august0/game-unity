using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimits : MonoBehaviour
{
    private Camera mainCamera;
    private float minX, maxX, minY, maxY;

    private void Start()
    {
        mainCamera = Camera.main;

        // Obter os limites da tela em coordenadas do mundo
        Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(Vector3.zero);
        Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        // Definir os limites do mapa
        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;
    }

    private void LateUpdate()
    {
        // Limitar a posição do jogador aos limites do mapa
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }
}
