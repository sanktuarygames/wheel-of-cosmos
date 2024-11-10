using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sanktuary.Sometimes.Resources
{
	public class TiltEffect : MonoBehaviour
	{
		public Color color1 = Color.white;
		public Color color2 = Color.white;
		public float duration = 1f;

		void Update()
		{
			float t = Mathf.PingPong(Time.time, duration) / duration;
			this.GetComponent<TMP_Text>().color = Color.Lerp(color1, color2, t);
		}
	}
}