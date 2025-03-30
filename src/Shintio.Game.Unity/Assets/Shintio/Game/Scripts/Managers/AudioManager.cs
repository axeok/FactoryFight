using Cysharp.Threading.Tasks;
using UnityEngine;
using AudioSettings = Shintio.Game.Models.Settings.AudioSettings;

namespace Shintio.Game.Managers
{
	public class AudioManager : ManagerBase
	{
		private readonly AudioSettings _settings;
		private AudioSource _audioSource;

		public AudioManager(AudioSettings settings)
		{
			_settings = settings;

			_audioSource = new GameObject()
				.AddComponent<AudioSource>();
		}

		protected override UniTask<bool> InitializeInternalAsync()
		{
			AudioListener.volume = _settings.MasterVolume;

			return UniTask.FromResult(true);
		}

		public void PlayShot(AudioClip clip)
		{
			_audioSource.PlayOneShot(clip);
		}

		public void PlayClick()
		{
			PlayShot(_settings.ClickSound);
		}

		public void PlayHover()
		{
			PlayShot(_settings.HoverSound);
		}
	}
}