using Shintio.Game.Models.Settings;
using UnityEngine;
using AudioSettings = Shintio.Game.Models.Settings.AudioSettings;

namespace Shintio.Game.ScriptableObjects
{
	[CreateAssetMenu(menuName = "Scriptable Objects/Settings")]
	public class GameSettings : ScriptableObject
	{
		[SerializeField] public CameraSettings Camera = null!;
		[SerializeField] public AudioSettings Audio = null!;
	}
}