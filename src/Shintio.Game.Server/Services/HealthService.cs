using MagicOnion;
using MagicOnion.Server;
using Shintio.Game.Shared.Services;

namespace Shintio.Game.Server.Services;

public class HealthService : ServiceBase<IHealthService>, IHealthService
{
	public async UnaryResult<bool> Ping()
	{
		return true;
	}

	public async UnaryResult<DateTime> GetServerTime()
	{
		return DateTime.UtcNow;
	}
}