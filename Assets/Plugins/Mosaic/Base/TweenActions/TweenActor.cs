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
            switch (action.actionType)
            {
                case ActionType.Transform:
                        return Act(action, o.transform);
                
                case ActionType.RectTransform:
                        return Act(action, o.GetComponent<RectTransform>());

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
            if (action.actionType != ActionType.Transform || !t)
            {
                Debug.Log("Transform");
                LogTypeError();
                return null;
            }

            Vector3 end;

            switch (action.transformActionType)
            {
                case TransformActionType.Position:
                    end = (action.local) ? t.localPosition : t.position;
                    FindEndPoint(action, ref end);

                    return TweenPosition(action, t, end);

                case TransformActionType.Rotation:
                    end = (action.local) ? t.localRotation.eulerAngles : t.rotation.eulerAngles;
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

        public static Tween Act(TweenAction action, RectTransform t)
        {
            if (action.actionType != ActionType.RectTransform || !t)
            {
				Debug.Log("RectTransform");
				LogTypeError();
                return null;
            }

            Vector3 end;

            switch (action.transformActionType)
            {
                case TransformActionType.Position:
                    end = (action.local) ? t.localPosition : t.position;
                    FindEndPoint(action, ref end);

                    return TweenPosition(action, t, end);

                case TransformActionType.Rotation:
                    end = (action.local) ? t.localRotation.eulerAngles : t.rotation.eulerAngles;
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
            if (action.actionType != ActionType.Color || !r)
            {
				Debug.Log("Color");
				LogTypeError();
                return null;
            }

            Color end = action.cValueAt;
            FindEndPoint(action, r.color, ref end);

            return TweenColor(action, r, end);
        }

        public static Tween Act(TweenAction action, Image i)
        {
            if (action.actionType != ActionType.Color || !i)
            {
				Debug.Log("Color");
				LogTypeError();
                return null;
            }

            Color end = action.cValueAt;
            FindEndPoint(action, i.color, ref end);

            return TweenColor(action, i, end);
        }

        public static Sequence ActSequence(TweenActionSequence seq, GameObject o)
        {
            Sequence s = DOTween.Sequence();

            foreach (TweenAction action in seq.appendingActions)
            {
                s.Append(Act(action, o));
            }

            foreach (TweenActionSequence.InsertingAction action in seq.insertingActions)
            {
                s.Insert(action.insertingTime, Act(action.insertingAction, o));
            }

            return s;
        }
        #endregion

        #region Actual Tween Process
        //Transform
        private static void FindEndPoint(TweenAction action, ref Vector3 end)
        {
            if (action.transformActionType == TransformActionType.Scale)
            {
                if (action.setAt)
                    end = (action.vector3) ? action.v3ValueAt : (Vector3)action.v2ValueAt;
                else if (!action.multiply)
                    end += (action.vector3) ? action.v3ValueAdd : (Vector3)action.v2ValueAdd;
                else
                    end *= action.multiplier;

                return;
            }

            if (action.setAt)
                end = (action.vector3) ? action.v3ValueAt : (Vector3)action.v2ValueAt;
            else
                end += (action.vector3) ? action.v3ValueAdd : (Vector3)action.v2ValueAdd;

            return;
        }

        //Color
        private static void FindEndPoint(TweenAction action, Color start, ref Color end)
        {
            switch (action.colorActionType)
            {
                case ColorActionType.NotAlpha:
                    end.a = start.a;
                    break;

                case ColorActionType.Alpha:
                    end = start;
                    end.a = action.cValueAt.a;
                    break;
                
                case ColorActionType.Both:
                    end = action.cValueAt;
                    break;

                default:
                    LogTypeError();
                    break;
            }
        }

        //Tween Transform
        private static Tween TweenPosition(TweenAction action, Transform t, Vector3 end)
        {
            if (action.local)
            {
                if (action.customEase)
                    return t.DOLocalMove(end, action.duration).SetEase(action.easeCurve);
                else
                    return t.DOLocalMove(end, action.duration).SetEase(action.ease);
            }
            else
            {
                if (action.customEase)
                    return t.DOMove(end, action.duration).SetEase(action.easeCurve);
                else
                    return t.DOMove(end, action.duration).SetEase(action.ease);
            }
        }

        private static Tween TweenRotation(TweenAction action, Transform t, Vector3 end)
        {
            if (action.local)
            {
                if (action.customEase)
                    return t.DOLocalRotate(end, action.duration).SetEase(action.easeCurve);
                else
                    return t.DOLocalRotate(end, action.duration).SetEase(action.ease);
            }
            else
            {
                if (action.customEase)
                    return t.DORotate(end, action.duration).SetEase(action.easeCurve);
                else
                    return t.DORotate(end, action.duration).SetEase(action.ease);
            }
        }

        private static Tween TweenScale(TweenAction action, Transform t, Vector3 end)
        {
            if (action.customEase)
                return t.DOScale(end, action.duration).SetEase(action.easeCurve);
            else
                return t.DOScale(end, action.duration).SetEase(action.ease);
        }

        //Rect Transform
        private static Tween TweenRectPosition(TweenAction action, RectTransform t, Vector3 end)
        {
            if (action.local)
            {
                if (action.customEase)
                    return t.DOLocalMove(end, action.duration).SetEase(action.easeCurve);
                else
                    return t.DOLocalMove(end, action.duration).SetEase(action.ease);
            }
            else
            {
                if (action.customEase)
                    return t.DOMove(end, action.duration).SetEase(action.easeCurve);
                else
                    return t.DOMove(end, action.duration).SetEase(action.ease);
            }
        }

        private static Tween TweenRectRotation(TweenAction action, RectTransform t, Vector3 end)
        {
            if (action.local)
            {
                if (action.customEase)
                    return t.DOLocalRotate(end, action.duration).SetEase(action.easeCurve);
                else
                    return t.DOLocalRotate(end, action.duration).SetEase(action.ease);
            }
            else
            {
                if (action.customEase)
                    return t.DORotate(end, action.duration).SetEase(action.easeCurve);
                else
                    return t.DORotate(end, action.duration).SetEase(action.ease);
            }
        }

        private static Tween TweenRectScale(TweenAction action, RectTransform t, Vector3 end)
        {
            if (action.customEase)
                return t.DOScale(end, action.duration).SetEase(action.easeCurve);
            else
                return t.DOScale(end, action.duration).SetEase(action.ease);
        }

        //Tween Color
        private static Tween TweenColor(TweenAction action, SpriteRenderer r, Color end)
        {
            if (action.customEase)
                return r.DOColor(end, action.duration).SetEase(action.easeCurve);
            else
                return r.DOColor(end, action.duration).SetEase(action.ease);
        }

        private static Tween TweenColor(TweenAction action, Image i, Color end)
        {
            if (action.customEase)
                return i.DOColor(end, action.duration).SetEase(action.easeCurve);
            else
                return i.DOColor(end, action.duration).SetEase(action.ease);
        }
        #endregion
    }
}
