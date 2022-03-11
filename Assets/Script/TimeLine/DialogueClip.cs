using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class DialogueClip :  PlayableAsset, ITimelineClipAsset
{
    public DialogueBehaviour template = new DialogueBehaviour();

    public Sprite picture_Asset;
    public string str_Asset;
    public ExposedReference<Image> pannel;
    public bool hasToPause_Asset;

    public ClipCaps clipCaps
{
    get { return ClipCaps.None; }
}

public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
{
    var playable = ScriptPlayable<DialogueBehaviour>.Create(graph, template);

        playable.GetBehaviour().dialogueCG = picture_Asset;
        playable.GetBehaviour().dialogueLine = str_Asset;
        playable.GetBehaviour().hasToPause = hasToPause_Asset;
        playable.GetBehaviour()._pannel = pannel.Resolve(graph.GetResolver());
        return playable;
}
}
