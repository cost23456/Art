using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    private TGUIRef mTRef;
    private void Awake()
    {
        this.mTRef = this.GetComponent<TGUIRef>();

    }
    private void Start()
    {
        Debug.Log("ScenesManager Æô¶¯³É¹¦£¡");
        foreach (GameObject obj in mTRef.RefList)
        {
            DontDestroyOnLoad(obj);
        }
    }
    public void LoadVillage()
    {
        SceneManager.LoadScene("village");
    }   
}
