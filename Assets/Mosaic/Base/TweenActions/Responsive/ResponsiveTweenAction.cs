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
		[SerializeField] private Vector2 anchor;

		[SerializeField] private float duration;

		[SerializeField] private bool customEase;
		[SerializeField] private Ease ease;
		[SerializeField] private AnimationCurve easeCurve;

		public ResponsiveTweenAction(TweenAction action)
		{
			this.transformActionType = action.TransformActionType;
			this.local = action.Local;
			this.setAt = action.SetAt;
			this.multiply = action.Multiply;
			this.multiplier = action.Multiplier;
			this.v2ValueAt = action.V2ValueAt;
			this.v2ValueAdd = action.V2ValueAdd;
			this.anchor = new Vector2();
			this.duration = action.Duration;
			this.customEase = action.CustomEase;
			this.ease = action.Ease;
			this.easeCurve = action.EaseCurve;
		}

		#region Properties
		public TransformActionType TransformActionType => transformActionType;

		public bool Local => local;
		public bool SetAt => setAt;
		public bool Multiply => multiply;

		public float Multiplier => multiplier;

		public Vector2 V2ValueAt => v2ValueAt;
		public Vector2 V2ValueAdd => v2ValueAdd;
		public Vector2 Anchor => anchor;

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