using UnityEngine;
using DG.Tweening;

namespace Mosaic.Base.TweenActions
{
	[CreateAssetMenu(fileName = "ResponsiveTweenActionObject", menuName = "TweenAction/Responsive Action", order = 1)]
	public class ResponsiveTweenAction : TweenActionCore
	{
		[SerializeField] private TransformActionType transformActionType;

		[SerializeField] private bool local;
		[SerializeField] private bool setAt;
		[SerializeField] private bool multiply;

		[SerializeField] private float multiplier;

		[SerializeField] private Vector2 v2ValueAt;
		[SerializeField] private Vector2 v2ValueAdd;

		[SerializeField] private float duration;

		[SerializeField] private bool customEase;
		[SerializeField] private Ease ease;
		[SerializeField] private AnimationCurve easeCurve;

		#region Properties
		public TransformActionType TransformActionType => transformActionType;

		public bool Local => local;
		public bool SetAt => setAt;
		public bool Multiply => multiply;

		public float Multiplier => multiplier;

		public Vector2 V2ValueAt => v2ValueAt;
		public Vector2 V2ValueAdd => v2ValueAdd;

		public float Duration => duration;

		public bool CustomEase => customEase;
		public Ease Ease => ease;
		public AnimationCurve EaseCurve => easeCurve;
		#endregion

		public override Tween Act(GameObject o)
		{
			return ResponsiveTweenActor.Act(this, o.GetComponent<RectTransform>());
		}
	}
}