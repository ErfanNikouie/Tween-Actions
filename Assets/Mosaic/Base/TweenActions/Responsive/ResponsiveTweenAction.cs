using UnityEngine;
using DG.Tweening;

namespace Mosaic.Base.TweenActions
{
	[CreateAssetMenu(fileName = "ResponsiveTweenActionObject", menuName = "TweenAction/Responsive Action", order = 1)]
	public class ResponsiveTweenAction : TweenActionCore
	{
		public TransformActionType transformActionType;

		public bool setAt;
		public bool multiply;

		public float multiplier;

		public Vector2 v2ValueAt;
		public Vector2 v2ValueAdd;

		public float duration;

		public bool customEase;
		public Ease ease;
		public AnimationCurve easeCurve;

		public override Tween Act(GameObject o)
		{
			//return TweenActor.Act(this, o);
			return null;
		}
	}
}