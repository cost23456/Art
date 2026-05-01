using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPUzzle : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            UIManager.Instance.ContrlPuzzle();
        }
    }
}
