using System;
using UnityEditor.Rendering;

namespace Shintio.Game.Models.Settings
{
	[Serializable]
	public class CameraSettings
	{
		public CameraUI.ProjectionType Projection = CameraUI.ProjectionType.Perspective;
		public float Fov = 60;
	}
}