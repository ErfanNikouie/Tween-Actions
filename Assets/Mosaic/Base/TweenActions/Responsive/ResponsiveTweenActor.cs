using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Mosaic.Base.TweenActions
{
    public static class ResponsiveTweenActor
    {
		static Vector2 screenMultiplier = new Vector2();
		static bool init = false;

		public static void Initialize()
		{
			if (init)
				return;

			Vector2 refRes = Resources.LoadAll<ResponsiveTweenActionSettings>("MosaicScriptables")[0].ReferenceResolution;

			screenMultiplier = new Vector2(Screen.width / refRes.x, Screen.height / refRes.y);
		}

		public static Tween Act(ResponsiveTweenAction action, RectTransform t)
		{
			if (!init)
				Initialize();

			Vector2 end = new Vector2();

			switch (action.TransformActionType)
			{
				case TransformActionType.Position:
					end = (action.Local) ? t.localPosition : t.position;
					FindEndPoint(action, ref end, true);

					return TweenRectPosition(action, t, end);

				case TransformActionType.Rotation:
					end = (action.Local) ? t.localRotation.eulerAngles : t.rotation.eulerAngles;
					FindEndPoint(action, ref end, false);

					return TweenRectRotation(action, t, end);


				case TransformActionType.Scale:
					end = t.localScale;
					FindEndPoint(action, ref end, true);

					return TweenRectScale(action, t, end);

				default:
					return null;
			}
		}

		private static void FindEndPoint(ResponsiveTweenAction action, ref Vector2 end, bool responsive = true)
		{
			if (action.SetAt)
				end = action.V2ValueAt;
			else if(action.Multiply && action.TransformActionType == TransformActionType.Scale)
				end *= action.Multiplier;
			else
				end += action.V2ValueAdd;

			if(responsive)
				end *= screenMultiplier;
		}

		//TODO
		/*public static Sequence ActSequence(TweenActionSequence seq, GameObject o)
		{
			Sequence s = DOTween.Sequence();

			TweenAction[] append = seq.AppendingActions;
			TweenActionSequence.InsertingAction[] insert = seq.InsertingActions;

			foreach (TweenAction action in append)
				s.Append(Act(action, o));

			foreach (TweenActionSequence.InsertingAction action in insert)
				s.Insert(action.insertingTime, Act(action.insertingAction, o));

			return s;
		}*/

		//Rect Transform
		private static Tween TweenRectPosition(ResponsiveTweenAction action, RectTransform t, Vector3 end)
		{
			if (action.Local)
			{
				if (action.CustomEase)
					return t.DOLocalMove(end, action.Duration).SetEase(action.EaseCurve);

				return t.DOLocalMove(end, action.Duration).SetEase(action.Ease);
			}

			if (action.CustomEase)
				return t.DOMove(end, action.Duration).SetEase(action.EaseCurve);

			return t.DOMove(end, action.Duration).SetEase(action.Ease);
		}

		private static Tween TweenRectRotation(ResponsiveTweenAction action, RectTransform t, Vector3 end)
		{
			if (action.Local)
			{
				if (action.CustomEase)
					return t.DOLocalRotate(end, action.Duration).SetEase(action.EaseCurve);

				return t.DOLocalRotate(end, action.Duration).SetEase(action.Ease);
			}

			if (action.CustomEase)
				return t.DORotate(end, action.Duration).SetEase(action.EaseCurve);

			return t.DORotate(end, action.Duration).SetEase(action.Ease);
		}

		private static Tween TweenRectScale(ResponsiveTweenAction action, RectTransform t, Vector3 end)
		{
			if (action.CustomEase)
				return t.DOScale(end, action.Duration).SetEase(action.EaseCurve);

			return t.DOScale(end, action.Duration).SetEase(action.Ease);
		}
	}
}