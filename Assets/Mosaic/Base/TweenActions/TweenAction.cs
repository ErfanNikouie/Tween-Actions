using UnityEngine;
using DG.Tweening;

namespace Mosaic.Base.TweenActions
{
    [CreateAssetMenu(fileName = "TweenActionObject", menuName = "TweenAction/Action", order = 1)]
    public class TweenAction : TweenActionCore
    {
        [SerializeField] private ActionType actionType;
		[SerializeField] private TransformActionType transformActionType;
        [SerializeField] private ColorActionType colorActionType;

		[SerializeField] private bool local;
		[SerializeField] private bool setAt;
        [SerializeField] private bool vector3;
        [SerializeField] private bool multiply;
        
        [SerializeField] private float multiplier;
        
        [SerializeField] private Vector2 v2ValueAt;
        [SerializeField] private Vector3 v3ValueAt;
        
        [SerializeField] private Vector2 v2ValueAdd;
        [SerializeField] private Vector3 v3ValueAdd;
        
        [SerializeField] private Color cValueAt = Color.white;
        
        [SerializeField] private float duration;

        [SerializeField] private bool customEase;
        [SerializeField] private Ease ease;
        [SerializeField] private AnimationCurve easeCurve;

		#region Properties
		public ActionType ActionType => actionType;
        public TransformActionType TransformActionType => transformActionType;
        public ColorActionType ColorActionType => colorActionType;

        public bool Local => local;
        public bool SetAt => setAt;
        public bool Vector3 => vector3;
        public bool Multiply => multiply;

        public float Multiplier => multiplier;

        public Vector2 V2ValueAt => v2ValueAt;
        public Vector3 V3ValueAt => v3ValueAt;

        public Vector2 V2ValueAdd => v2ValueAdd;
        public Vector3 V3ValueAdd => v3ValueAdd;

        public Color CValueAt => cValueAt;

        public float Duration => duration;

        public bool CustomEase => customEase;
        public Ease Ease => ease;
        public AnimationCurve EaseCurve => easeCurve;
		#endregion


		public override Tween Act(GameObject o)
        {
            return TweenActor.Act(this, o);
        }
    }
}
