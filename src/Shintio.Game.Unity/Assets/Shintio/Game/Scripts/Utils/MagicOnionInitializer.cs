using Cysharp.Net.Http;
using Grpc.Net.Client;
using MagicOnion.Client;
using MagicOnion.Unity;
using Shintio.Game.Shared.Services;
using UnityEngine;

namespace Shintio.Game.Utils
{
	public static class MagicOnionInitializer
	{
		public static bool IsReady { get; private set; } = false;

#if UNITY_2019_4_OR_NEWER
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#elif NET5_0_OR_GREATER
		[System.Runtime.CompilerServices.ModuleInitializer]
#endif
		public static void OnRuntimeInitialize()
		{
			MagicOnionGeneratedClientInitializer.RegisterMemoryPackFormatters();

			GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(() => new GrpcChannelOptions()
			{
				HttpHandler = new YetAnotherHttpHandler()
				{
					Http2Only = true,
				},
				DisposeHttpClient = true,
			}));

			IsReady = true;
		}
	}

	[MagicOnionClientGeneration(typeof(IHealthService),
		Serializer = MagicOnionClientGenerationAttribute.GenerateSerializerType.MemoryPack)]
	public partial class MagicOnionGeneratedClientInitializer
	{
	}
}