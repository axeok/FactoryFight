using Cysharp.Threading.Tasks;
using UnityEngine;
using AudioSettings = Shintio.Game.Models.Settings.AudioSettings;

namespace Shintio.Game.Managers
{
	public class AudioManager : ManagerBase
	{
		private readonly AudioSettings _settings;

		public AudioManager(AudioSettings settings)
		{
			_settings = settings;
		}

		protected override UniTask<bool> InitializeInternalAsync()
		{
			AudioListener.volume = _settings.MasterVolume;

			return UniTask.FromResult(true);
		}
	}
}