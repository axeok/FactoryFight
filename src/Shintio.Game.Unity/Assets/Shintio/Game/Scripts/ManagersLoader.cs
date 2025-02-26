using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Shintio.Game.Managers;
using UnityEngine;
using VContainer.Unity;

namespace Shintio.Game
{
	public class ManagersLoader : IAsyncStartable
	{
		private readonly AudioManager _audioManager;
		private readonly CameraManager _cameraManager;
		private readonly RequestsManager _requestsManager;
		private readonly ScenesManager _scenesManager;

		public ManagersLoader(
			AudioManager audioManager,
			CameraManager cameraManager,
			RequestsManager requestsManager,
			ScenesManager scenesManager
		)
		{
			_audioManager = audioManager;
			_cameraManager = cameraManager;
			_requestsManager = requestsManager;
			_scenesManager = scenesManager;
		}

		public async UniTask StartAsync(CancellationToken cancellation = new())
		{
			// await TryInitializeManager(_requestsManager);
			await TryInitializeManager(_scenesManager);
			await TryInitializeManager(_cameraManager);
			await TryInitializeManager(_audioManager);
		}

		private async UniTask TryInitializeManager(ManagerBase manager)
		{
			try
			{
				if (await manager.InitializeAsync())
				{
					Debug.Log($"{manager.GetType().Name} successfully initialized!");
				}
				else
				{
					Debug.LogError($"Failed to initialize {manager.GetType().Name}!");
				}
			}
			catch (Exception e)
			{
				Debug.LogError($"Failed to initialize {manager.GetType().Name} with next exception ->");
				Debug.LogException(e);
			}
		}
	}
}