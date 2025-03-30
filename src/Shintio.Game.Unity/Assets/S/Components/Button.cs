using Shintio.Game.Utils;
using UnityEngine.UIElements;

namespace S
{
	[UxmlElement]
	public partial class Button : UnityEngine.UIElements.Button
	{
		public Button()
		{
			AddToClassList("s-btn");
			
			clicked += OnClicked;
			RegisterCallback<MouseOverEvent>(OnOver);
		}

		private void OnClicked()
		{
			Services.AudioManager.PlayClick();
		}

		private void OnOver(MouseOverEvent evt)
		{
			Services.AudioManager.PlayHover();
		}
	}
}