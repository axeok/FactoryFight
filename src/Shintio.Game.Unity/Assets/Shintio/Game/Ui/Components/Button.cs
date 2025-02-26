using UnityEngine.UIElements;

namespace Shintio.Game.Ui.Components
{
	[UxmlElement]
	public partial class Button : UnityEngine.UIElements.Button
	{
		public Button()
		{
			AddToClassList("s-btn");
		}
	}
}