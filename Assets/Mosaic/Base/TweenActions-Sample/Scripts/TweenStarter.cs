using UnityEngine;

namespace Mosaic.Base.TweenActions.Sample
{
	public class TweenStarter : MonoBehaviour
	{
		[SerializeField] private TweenActionCore action;

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				action.Act(this.gameObject);
		}
	}
}
