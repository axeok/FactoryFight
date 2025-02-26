using Cysharp.Threading.Tasks;
using Shintio.Game.Models.Settings;
using Shintio.Unity;
using UnityEditor.Rendering;
using UnityEngine;

namespace Shintio.Game.Managers
{
	public class CameraManager : ManagerBase
	{
		private readonly CameraSettings _settings;

		public CameraManager(CameraSettings settings)
		{
			_settings = settings;

			var mainCamera = Camera.main;
			if (mainCamera == null)
			{
				Debug.LogWarning("Main Camera not found, creating new one...");

				mainCamera = new GameObject("Main Camera")
					.AddComponent<Camera>();

				mainCamera.tag = Tags.MainCamera;
			}

			MainCamera = mainCamera;
			CurrentCamera = mainCamera;
		}

		public Camera MainCamera { get; private set; }
		public Camera CurrentCamera { get; private set; }

		protected override UniTask<bool> InitializeInternalAsync()
		{
			ApplySettings();

			return UniTask.FromResult(true);
		}

		private void ApplySettings()
		{
			MainCamera.orthographic = _settings.Projection == CameraUI.ProjectionType.Orthographic;
			MainCamera.fieldOfView = _settings.Fov;
		}
	}
}