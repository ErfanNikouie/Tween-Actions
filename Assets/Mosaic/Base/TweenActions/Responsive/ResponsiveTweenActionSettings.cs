using UnityEngine;

namespace Mosaic.Base.TweenActions
{
	[CreateAssetMenu(fileName = "Responsive Settings", menuName = "TweenAction/Responsive Settings", order = 0)]
	public class ResponsiveTweenActionSettings : ScriptableObject
    {
        [SerializeField] private Vector2 referenceResolution = new Vector2(1920, 1080);

        public Vector2 ReferenceResolution => referenceResolution;
    }
}
