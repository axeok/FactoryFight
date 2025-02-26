using System;
using Cysharp.Threading.Tasks;
using MagicOnion;
using MagicOnion.Client;
using MagicOnion.Serialization.MemoryPack;
using Shintio.Game.Shared.Services;
using Shintio.Game.Utils;

namespace Shintio.Game.Managers
{
	public class RequestsManager : ManagerBase
	{
		private static readonly bool ServerDisabled = false;

		private static readonly TimeSpan InitializeTimeout = TimeSpan.FromSeconds(5);

		private readonly GrpcChannelx _channel;

		public RequestsManager()
		{
			_channel = GrpcChannelx.ForAddress("http://localhost:5244");
		}

		public T CreateClient<T>() where T : IService<T>
		{
			return MagicOnionClient.Create<T>(_channel, MemoryPackMagicOnionSerializerProvider.Instance);
		}

		protected override async UniTask<bool> InitializeInternalAsync()
		{
			if (ServerDisabled)
			{
				return false;
			}

			var time = DateTime.UtcNow;
			while (!MagicOnionInitializer.IsReady)
			{
				if (DateTime.UtcNow - time > InitializeTimeout)
				{
					return false;
				}

				await UniTask.Yield();
			}

			return await CreateClient<IHealthService>().Ping();
		}
	}
}