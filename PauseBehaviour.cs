using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class PauseBehaviour : PlayableBehaviour
{
    PlayableDirector myTimeline;
    bool isPaused = false;
    bool alreadyPlayed = false;

    public KeyCode key;

    public override void OnPlayableCreate(Playable playable)
    {
        base.OnPlayableCreate(playable);
        myTimeline = playable.GetGraph().GetResolver() as PlayableDirector;
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        base.OnBehaviourPlay(playable, info);
        
        if(isPaused == false && alreadyPlayed == false)
        {
            myTimeline.Pause();
            isPaused = true;
            CoroutineRunner.instance.StartCoroutine(WaitForInput());
        }

        if (Input.GetKeyDown(key))
        {
            //bugfix: moves the playable just a bit forward in time  when input is pressed to 'wake it up' and enable the resume
            playable.SetTime(playable.GetTime() + .00001f);
        }
    }

    public IEnumerator WaitForInput()
    {
        while (isPaused)
        {
            yield return null;
            if (Input.GetKeyDown(key))
            {
                isPaused = false;
                alreadyPlayed = true;
                myTimeline.Resume();
                break;
            }
        }
    }
}
