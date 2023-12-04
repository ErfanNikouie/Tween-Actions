using DG.Tweening;
using UnityEngine;

namespace Mosaic.Base.TweenActions
{
    [CreateAssetMenu(fileName = "TweenActionObject", menuName = "TweenAction/Sequence", order = 2)]

    public class TweenActionSequence : TweenActionCore
    {
        [SerializeField] private TweenAction[] appendingActions;
        
        [System.Serializable]
        public struct InsertingAction
        {
            public float insertingTime;
            public TweenAction insertingAction;
        }

        [SerializeField] private InsertingAction[] insertingActions;

        public TweenAction[] AppendingActions => appendingActions;
        public InsertingAction[] InsertingActions => insertingActions;

        public override Tween Act(GameObject o)
        {
            return TweenActor.ActSequence(this, o);
        }
    }
}