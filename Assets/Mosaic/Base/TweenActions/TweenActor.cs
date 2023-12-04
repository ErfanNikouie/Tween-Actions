using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Mosaic.Base.TweenActions
{
    public static class TweenActor
    {
		private static void LogTypeError()
        {
            Debug.LogError("Wrong type to tween!");
        }

        #region Act
        public static Tween Act(TweenAction action, GameObject o)
        {
            switch (action.ActionType)
            {
                case ActionType.Transform:
                        return Act(action, o.transform);

                case ActionType.Color:
                    SpriteRenderer r = o.GetComponent<SpriteRenderer>();
                    if (r != null)
                        return Act(action, r);
                    else
                        return Act(action, o.GetComponent<Image>());

                default:
                    return null;
            }
        }

        public static Tween Act(TweenAction action, Transform t)
        {
            if (action.ActionType != ActionType.Transform || !t)
            {
                Debug.Log("Transform");
                LogTypeError();
                return null;
            }

            Vector3 end = new Vector3();

            switch (action.TransformActionType)
            {
                case TransformActionType.Position:
                    end = (action.Local) ? t.localPosition : t.position;
                    FindEndPoint(action, ref end);

                    return TweenPosition(action, t, end);

                case TransformActionType.Rotation:
                    end = (action.Local) ? t.localRotation.eulerAngles : t.rotation.eulerAngles;
                    FindEndPoint(action, ref end);

                    return TweenRotation(action, t, end);
                        

                case TransformActionType.Scale:
                    end = t.localScale;
                    FindEndPoint(action, ref end);

                    return TweenScale(action, t, end);

                default:
                    return null;
            }
        }

        public static Tween Act(TweenAction action, SpriteRenderer r)
        {
            if (action.ActionType != ActionType.Color || !r)
            {
				Debug.Log("Color");
				LogTypeError();
                return null;
            }

            Color end = action.CValueAt;
            FindEndPoint(action, r.color, ref end);

            return TweenColor(action, r, end);
        }

        public static Tween Act(TweenAction action, Image i)
        {
            if (action.ActionType != ActionType.Color || !i)
            {
				Debug.Log("Color");
				LogTypeError();
                return null;
            }

            Color end = action.CValueAt;
            FindEndPoint(action, i.color, ref end);

            return TweenColor(action, i, end);
        }

        public static Sequence ActSequence(TweenActionSequence seq, GameObject o)
        {
            Sequence s = DOTween.Sequence();

            TweenAction[] append = seq.AppendingActions;
            TweenActionSequence.InsertingAction[] insert = seq.InsertingActions;

            foreach (TweenAction action in append)
                s.Append(Act(action, o));

            foreach (TweenActionSequence.InsertingAction action in insert)
                s.Insert(action.insertingTime, Act(action.insertingAction, o));

            return s;
        }
        #endregion

        #region Actual Tween Process

        //Transform
        private static void FindEndPoint(TweenAction action, ref Vector3 end)
        {
            if (action.SetAt)
                end = (action.Vector3) ? action.V3ValueAt : (Vector3)action.V2ValueAt;
			else if (action.Multiply && action.TransformActionType == TransformActionType.Scale)
				end *= action.Multiplier;
			else
                end += (action.Vector3) ? action.V3ValueAdd : (Vector3)action.V2ValueAdd;
        }

        //Color
        private static void FindEndPoint(TweenAction action, Color start, ref Color end)
        {
            switch (action.ColorActionType)
            {
                case ColorActionType.NotAlpha:
                    end.a = start.a;
                    break;

                case ColorActionType.Alpha:
                    end = start;
                    end.a = action.CValueAt.a;
                    break;
                
                case ColorActionType.Both:
                    end = action.CValueAt;
                    break;

                default:
                    LogTypeError();
                    break;
            }
        }

        //Tween Transform
        private static Tween TweenPosition(TweenAction action, Transform t, Vector3 end)
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

        private static Tween TweenRotation(TweenAction action, Transform t, Vector3 end)
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

        private static Tween TweenScale(TweenAction action, Transform t, Vector3 end)
        {
            if (action.CustomEase)
                return t.DOScale(end, action.Duration).SetEase(action.EaseCurve);

            return t.DOScale(end, action.Duration).SetEase(action.Ease);
        }

        //Tween Color
        private static Tween TweenColor(TweenAction action, SpriteRenderer r, Color end)
        {
            if (action.CustomEase)
                return r.DOColor(end, action.Duration).SetEase(action.EaseCurve);

            return r.DOColor(end, action.Duration).SetEase(action.Ease);
        }

        private static Tween TweenColor(TweenAction action, Image i, Color end)
        {
            if (action.CustomEase)
                return i.DOColor(end, action.Duration).SetEase(action.EaseCurve); 

            return i.DOColor(end, action.Duration).SetEase(action.Ease);
        }
        #endregion
    }
}
