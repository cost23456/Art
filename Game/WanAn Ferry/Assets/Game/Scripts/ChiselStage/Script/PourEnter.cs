using UnityEngine;

public class PourEnter : MonoBehaviour
{
    [Header("拖拽赋值")]
    public GameObject cam3;
    public GameObject cam1;
    public GameObject player;

    private bool inArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) inArea = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) inArea = false;
    }

    void Update()
    {
        if (inArea && Input.GetKeyDown(KeyCode.E))
        {
            cam3.SetActive(false);
            cam1.SetActive(true);
            player.SetActive(false);
        }
    }
}