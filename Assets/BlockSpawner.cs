using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab; // Prefab del bloque que se va a instanciar
    public Transform spawnHeight;  // La altura donde se instanciar� el bloque
    private GameObject currentBlock; // El bloque actual que est� en el aire

    private bool isInAir = true; // Detectar si el bloque est� en el aire
    private bool hasTouchedBase = false; // Detectar si el bloque toc� la base

    private void Start()
    {
        SpawnBlock();
    }

    private void Update()
    {
        if (currentBlock != null)
        {
            // Detectar si el bloque est� en el aire
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

    // M�todo para instanciar un nuevo bloque
    public void SpawnBlock()
    {
        currentBlock = Instantiate(blockPrefab, spawnHeight.position, Quaternion.identity);
        isInAir = true;
        hasTouchedBase = false;
    }

    // M�todo para verificar si el bloque est� en el aire
    public bool IsInAir()
    {
        return isInAir;
    }

    // M�todo para verificar si el bloque toc� la base
    public bool HasTouchedBase()
    {
        return hasTouchedBase;
    }
}
