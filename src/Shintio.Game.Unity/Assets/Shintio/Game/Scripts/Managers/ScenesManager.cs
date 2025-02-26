using Cysharp.Threading.Tasks;
using Shintio.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shintio.Game.Managers
{
	public class ScenesManager : ManagerBase
	{
		public ScenesManager()
		{
		}

		protected override UniTask<bool> InitializeInternalAsync()
		{
			return UniTask.FromResult(true);
		}

		public async UniTask ChangeScene(Scenes.SceneInfo scene)
		{
			await SceneManager.LoadSceneAsync(scene.Name, LoadSceneMode.Single);
		}

		public async UniTask AddScene(Scenes.SceneInfo scene)
		{
			await SceneManager.LoadSceneAsync(scene.Name, LoadSceneMode.Additive);
		}
	}
}