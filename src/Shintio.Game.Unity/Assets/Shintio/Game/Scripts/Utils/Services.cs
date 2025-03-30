using Shintio.Game.Managers;
using VContainer;

namespace Shintio.Game.Utils
{
	public static class Services
	{
		private static AudioManager? _audioManager = null;
		public static AudioManager AudioManager => _audioManager ??= Scope.Container.Resolve<AudioManager>();

		public static GlobalLifetimeScope Scope { get; private set; } = null!;

		public static void SetScope(GlobalLifetimeScope scope)
		{
			Scope = scope;
		}
	}
}