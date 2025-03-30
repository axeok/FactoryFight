using MessagePipe;
using Shintio.Game.Managers;
using Shintio.Game.ScriptableObjects;
using Shintio.Game.Utils;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Shintio.Game
{
	public class GlobalLifetimeScope : LifetimeScope
	{
		[SerializeField] private GameSettings Settings = null!;

		protected override void Configure(IContainerBuilder builder)
		{
			Services.SetScope(this);
			
			RegisterMessagePipe(builder);
			RegisterServices(builder);

			DontDestroyOnLoad(this);
		}

		private void RegisterServices(IContainerBuilder builder)
		{
			builder.RegisterInstance(Settings);
			builder.RegisterInstance(Settings.Audio);
			builder.RegisterInstance(Settings.Camera);

			builder.Register<AudioManager>(Lifetime.Singleton);
			builder.Register<CameraManager>(Lifetime.Singleton);
			builder.Register<RequestsManager>(Lifetime.Singleton);
			builder.Register<ScenesManager>(Lifetime.Singleton);

			builder.UseEntryPoints(Lifetime.Singleton, entryPoints => { entryPoints.Add<ManagersLoader>(); });

			builder.UseComponents(components =>
			{
				//
			});
		}

		private void RegisterMessagePipe(IContainerBuilder builder)
		{
			var messagePipeOptions = builder.RegisterMessagePipe();

			builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
		}
	}
}