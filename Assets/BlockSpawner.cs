using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Prefab del bloque que se va a instanciar
    public Transform spawnHeight;  // La altura donde se instanciará el bloque
    private GameObject currentBlock; // El bloque actual que está en el aire

    private bool isInAir = true; // Detectar si el bloque está en el aire
    private bool hasTouchedBase = false; // Detectar si el bloque tocó la base

    private void Start()
    {
        SpawnBlock();
    }

    private void Update()
    {
        if (currentBlock != null)
        {
            // Detectar si el bloque está en el aire
            if (isInAir && currentBlock.transform.position.y < spawnHeight.position.y)
            {
                isInAir = false;
            }

            // Detectar si el bloque ha tocado el bloque base
            if (!hasTouchedBase && !isInAir && currentBlock.GetComponent<Collider>().bounds.min.y <= 0)
            {
                hasTouchedBase = true;
                Debug.Log("El bloque ha tocado la base.");
            }
        }
    }

    // Método para instanciar un nuevo bloque
    public void SpawnBlock()
    {
        currentBlock = Instantiate(blockPrefab, spawnHeight.position, Quaternion.identity);
        isInAir = true;
        hasTouchedBase = false;
    }

    // Método para verificar si el bloque está en el aire
    public bool IsInAir()
    {
        return isInAir;
    }

    // Método para verificar si el bloque tocó la base
    public bool HasTouchedBase()
    {
        return hasTouchedBase;
    }
}
