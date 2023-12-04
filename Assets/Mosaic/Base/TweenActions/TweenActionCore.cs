using UnityEngine;
using DG.Tweening;

namespace Mosaic.Base.TweenActions
{
    #region  ENUMS:

    public enum ActionType
    {
        Transform,
        Color,
    }

    public enum TransformActionType
    {
        Position,
        Rotation,
        Scale
    }

    public enum ColorActionType
    {
        Alpha,
        NotAlpha,
        Both
    }
    #endregion

    public abstract class TweenActionCore : ScriptableObject
    {
        public abstract Tween Act(GameObject o);
    }
}