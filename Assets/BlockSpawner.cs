using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public Transform spawnHeight;
    private GameObject currentBlock;

    private bool isInAir = true;
    private bool hasTouchedBase = false;

    private void OnEnable()
    {
        InputController.OnTap += SpawnBlock;
    }

    private void OnDisable()
    {
        InputController.OnTap -= SpawnBlock;
    }

    private void Start()
    {
        SpawnBlock();
    }

    private void Update()
    {
        if (currentBlock != null)
        {
            if (isInAir && currentBlock.transform.position.y < spawnHeight.position.y)
            {
                isInAir = false;
            }

            if (!hasTouchedBase && !isInAir && currentBlock.GetComponent<Collider>().bounds.min.y <= 0)
            {
                hasTouchedBase = true;
                Debug.Log("El bloque ha tocado la base.");
            }
        }
    }

    public void SpawnBlock()
    {
        currentBlock = Instantiate(blockPrefab, spawnHeight.position, Quaternion.identity);
        isInAir = true;
        hasTouchedBase = false;
    }

    public bool IsInAir()
    {
        return isInAir;
    }

    public bool HasTouchedBase()
    {
        return hasTouchedBase;
    }
}
