using UnityEngine;
using DG.Tweening;

namespace Mosaic.Base.TweenActions
{
    [CreateAssetMenu(fileName = "TweenActionObject", menuName = "TweenAction/Action", order = 1)]
    public class TweenAction : TweenActionCore
    {
        public ActionType actionType;
        public TransformActionType transformActionType;
        public ColorActionType colorActionType;

        public bool local;
        public bool setAt;
        public bool vector3;
        public bool multiply;
        
        public float fValueAt;
        public float fValueAdd;

        public float multiplier;

        public Vector2 v2ValueAt;
        public Vector3 v3ValueAt;

        public Vector2 v2ValueAdd;
        public Vector3 v3ValueAdd;

        public Color cValueAt = Color.white;

        public float duration;

        public bool customEase;
        public Ease ease;
        public AnimationCurve easeCurve;

        public override Tween Act(GameObject o)
        {
            return TweenActor.Act(this, o);
        }
    }
}
