using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.Universal;

public class DirectorContrl : MonoBehaviour
{
    public bool isVelli = false;
    public List<PlayableDirector> Directors;
    public Cinemachine.CinemachineBrain cinemachineBrain;
    private void Start()
    {
        foreach (PlayableDirector director in Directors)
        {
            director.initialTime = 0;
        }
        if (isVelli)
        {
            ContrlDirectors(0);
        }
        else
        {
            this.cinemachineBrain.enabled = false;
        }
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
