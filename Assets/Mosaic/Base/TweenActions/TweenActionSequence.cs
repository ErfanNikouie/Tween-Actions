using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mosaic.Base.TweenActions
{
    [CreateAssetMenu(fileName = "TweenActionObject", menuName = "TweenAction/Sequence", order = 2)]

    public class TweenActionSequence : TweenActionCore
    {
        public TweenAction[] appendingActions;
        
        [System.Serializable]
        public struct InsertingAction
        {
            public float insertingTime;
            public TweenAction insertingAction;
        }

        public InsertingAction[] insertingActions;

        public override Tween Act(GameObject o)
        {
            return TweenActor.ActSequence(this, o);
        }
    }
}