using UnityEngine;
using UnityEngine.Playables;
using System;

[Serializable]
public class PauseClip : PlayableAsset
{
    [SerializeField] KeyCode key;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<PauseBehaviour>.Create(graph);
        PauseBehaviour pauseBehaviour = playable.GetBehaviour();
        pauseBehaviour.key = key;

        return playable;
    }
}





