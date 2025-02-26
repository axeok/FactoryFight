using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UIElements;

namespace Shintio.Editor.ScriptedImporters
{
	[ScriptedImporter(1, new[] { "scss", "sass" })]
	public class SassImporter : ScriptedImporter
	{
		// private static Type? _styleSheetImporterType = null;
		//
		// private static Type? StyleSheetImporterType => _styleSheetImporterType ??= AppDomain.CurrentDomain
		// 	.GetAssemblies()
		// 	.SelectMany(a => a.GetTypes())
		// 	.FirstOrDefault(t => t.Name == "StyleSheetImporterImpl");
		//
		// private static readonly MethodInfo ImportMethod =
		// 	StyleSheetImporterType!.GetMethod("Import", new[] { typeof(StyleSheet), typeof(string) })!;

		public override void OnImportAsset(AssetImportContext context)
		{
			var text = File.ReadAllText(context.assetPath);

			var textAsset = new TextAsset(text)
			{
				name = Path.GetExtension(context.assetPath)
			};
			context.AddObjectToAsset("source", textAsset);

			// if (string.IsNullOrWhiteSpace(text) || StyleSheetImporterType == null)
			// {
			// 	return;
			// }
			//
			// var sheetImporterImpl = Activator.CreateInstance(StyleSheetImporterType, context);
			//
			// var instance = ScriptableObject.CreateInstance<StyleSheet>();
			// instance.name = Path.GetFileNameWithoutExtension(context.assetPath);
			// instance.hideFlags = HideFlags.NotEditable;
			//
			// ImportMethod.Invoke(sheetImporterImpl, new object[] { instance, text });
			//
			// context.AddObjectToAsset("stylesheet", instance);
			// context.SetMainObject(instance);
		}
	}
}