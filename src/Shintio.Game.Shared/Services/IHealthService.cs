using System;
using MagicOnion;

namespace Shintio.Game.Shared.Services
{
	public interface IHealthService : IService<IHealthService>
	{
		UnaryResult<bool> Ping();
		UnaryResult<DateTime> GetServerTime();
	}
}