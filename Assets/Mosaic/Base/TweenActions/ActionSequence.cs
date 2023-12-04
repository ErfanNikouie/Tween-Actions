using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Mosaic.Base.TweenActions
{
    [System.Serializable]
    public class ActionSequence
    {
        public TweenAction[] actions;

        public Sequence PlayInSequence(GameObject o)
        {
            Sequence s = DOTween.Sequence();

            foreach (TweenAction action in actions)
            {
                s.Append(TweenActor.Act(action, o));
            }
            return s;
        }

        public Sequence PlayInSequence(Transform t = null, SpriteRenderer r = null)
        {
            Sequence s = DOTween.Sequence();

            foreach (TweenAction action in actions)
            {
                if(r && action.actionType == ActionType.Color)
                    s.Append(TweenActor.Act(action, r));
                else
                    s.Append(TweenActor.Act(action, t));
            }
            return s;
        }

        public void PlayAll(GameObject o)
        {
            foreach (TweenAction action in actions)
            {
                TweenActor.Act(action, o);
            }
        }

        public List<Tween> PlayAll(Transform t = null, SpriteRenderer r = null)
        {
            List<Tween> tweens = new List<Tween>();
            foreach (TweenAction action in actions)
            {
                Tween o = null;
                if(r && action.actionType == ActionType.Color)
                    o = TweenActor.Act(action, r);
                else
                    o = TweenActor.Act(action, t);

                if(o != null)
                    tweens.Add(o);
            }

            return tweens;
        }


        //Rect?
        public void PlayAll(RectTransform t = null, Image i = null)
        {
            foreach (TweenAction action in actions)
            {
                if(i && action.actionType == ActionType.Color)
                    TweenActor.Act(action, i);
                else
                    TweenActor.Act(action, t);
            }
        }
    }
}