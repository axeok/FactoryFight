using Cysharp.Threading.Tasks;

namespace Shintio.Game.Managers
{
	public abstract class ManagerBase
	{
		public async UniTask<bool> InitializeAsync()
		{
			return await InitializeInternalAsync();
		}

		protected abstract UniTask<bool> InitializeInternalAsync();
	}
}