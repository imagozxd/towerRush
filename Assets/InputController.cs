using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static event Action OnTap;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta un tap en pantalla
        {
            if (OnTap != null)
                OnTap(); // Disparar el evento de tap
            Debug.Log("hice tap");
        }
    }
}
