using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject baseBlock; // El bloque inicial
    public GameObject movingBlockPrefab; // El prefab del bloque que se mueve
    public Transform spawnPosition; // Lugar donde se spawnean los bloques móviles
    private GameObject currentMovingBlock;
    private float currentHeight = 0f;
    private int stackCount = 0;

    private void Start()
    {
        currentHeight = baseBlock.transform.position.y; // Comienza con la altura del bloque base
        SpawnNewBlock(); // Spawnear el primer bloque
    }

    private void SpawnNewBlock()
    {
        currentMovingBlock = Instantiate(movingBlockPrefab, spawnPosition.position, Quaternion.identity);
        // Suscribimos el evento del tap para detener el bloque cuando se pulse
        InputController.OnTap += StopMovingBlock;
    }

    private void StopMovingBlock()
    {
        // Detener el bloque
        InputController.OnTap -= StopMovingBlock; // Deja de escuchar el evento

        // Calculamos la diferencia
        float difference = GetDifferenceWidth(currentMovingBlock.transform, baseBlock.transform);

        // Si la diferencia es menor que el ancho del bloque, se corta el bloque
        if (difference < currentMovingBlock.transform.localScale.x)
        {
            CutWidth(currentMovingBlock, difference);
            UpdateHeight(currentMovingBlock); // Aumentamos la altura
            baseBlock = currentMovingBlock; // El nuevo bloque se convierte en la nueva base
            SpawnNewBlock(); // Spawnear el siguiente bloque
        }
        else
        {
            GameOver(); // Fin del juego si la diferencia es mayor que el tamaño del bloque
        }
    }

    private void CutWidth(GameObject block, float difference)
    {
        // Reducir el tamaño del bloque según la diferencia
        Vector3 newScale = block.transform.localScale;
        newScale.x -= difference; // Cortar el ancho
        block.transform.localScale = newScale;

        // Ajustar la posición para que coincida correctamente
        Vector3 newPosition = block.transform.position;
        newPosition.x += difference / 2;
        block.transform.position = newPosition;
    }

    private void UpdateHeight(GameObject block)
    {
        currentHeight += block.transform.localScale.y; // Aumentamos la altura con el tamaño del bloque
        stackCount++; // Incrementar contador de bloques apilados
        UIManager.Instance.UpdateStackCount(stackCount); // Actualizar el UI
    }

    private float GetDifferenceWidth(Transform movingBlock, Transform baseBlock)
    {
        // Calcula la diferencia de posición entre los bloques para ver cuánto deben cortarse
        return Mathf.Abs(movingBlock.position.x - baseBlock.position.x);
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        // Aquí puedes agregar más lógica para el final del juego
    }
}
