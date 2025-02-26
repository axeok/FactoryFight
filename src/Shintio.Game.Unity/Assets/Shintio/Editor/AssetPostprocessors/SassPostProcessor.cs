using System.IO;
using System.Linq;
using LibSass.Compiler;
using LibSass.Compiler.Options;
using UnityEditor;
using UnityEngine;

namespace Shintio.Editor.AssetPostprocessors
{
	public class SassAssetPostProcessor : AssetPostprocessor
	{
		private static void OnPostprocessAllAssets(
			string[] importedAssets,
			string[] deletedAssets,
			string[] movedAssets,
			string[] movedFromAssetPaths
		)
		{
			foreach (var asset in importedAssets.Where(a => a.EndsWith(".scss")))
			{
				GenerateCode(asset);
			}

			foreach (var asset in deletedAssets.Where(a => a.EndsWith(".scss")))
			{
				File.Delete(Path.ChangeExtension(asset, ".uss"));
			}
		}

		private static void GenerateCode(string assetPath)
		{
			var text = File.ReadAllText(assetPath);
			var newPath = Path.ChangeExtension(assetPath, ".uss");

			var result = new SassCompiler(new SassOptions
			{
				Data = text,
				OutputStyle = SassOutputStyle.Expanded,
			}).Compile();

			if (!string.IsNullOrWhiteSpace(result.ErrorMessage))
			{
				Debug.LogError(result.ErrorMessage);
			}

			File.WriteAllText(newPath, result.Output);

			AssetDatabase.Refresh();
		}
	}
}