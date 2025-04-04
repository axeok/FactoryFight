﻿using System;
using UnityEngine;

namespace Shintio.Game.Models.Settings
{
	[Serializable]
	public class AudioSettings
	{
		public float MasterVolume = 1.0f;

		public AudioClip ClickSound = null!;
		public AudioClip HoverSound = null!;
	}
}