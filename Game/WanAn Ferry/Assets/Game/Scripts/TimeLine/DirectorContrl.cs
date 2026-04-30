using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorContrl : MonoBehaviour
{
    public List<PlayableDirector> Directors;
    public Cinemachine.CinemachineBrain cinemachineBrain;
    private void Start()
    {
        foreach (PlayableDirector director in Directors)
        {
            director.initialTime = 0;
        }
        this.ContrlDirectors(0);
    }
    public void ContrlDirectors(int aIndex)
    {
        if (this.Directors[aIndex] == null) return;
        this.cinemachineBrain.enabled = true;
        this.Directors[aIndex].initialTime = 0;
        this.Directors[aIndex].Play();
        StartCoroutine(CloseDir(Directors[aIndex].duration,aIndex));
    }
    IEnumerator CloseDir(double timer, int aIndex)
    {
        yield return new WaitForSeconds((float)timer);
        this.Directors[aIndex].Stop();
        this.cinemachineBrain.enabled = false;
    }
}
