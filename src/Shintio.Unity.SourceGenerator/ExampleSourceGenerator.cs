﻿using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Shintio.Unity.SourceGenerator
{
	[Generator]
	public class ExampleSourceGenerator : ISourceGenerator
	{
		public void Execute(GeneratorExecutionContext context)
		{
			System.Console.WriteLine(System.DateTime.Now.ToString());

			var sourceBuilder = new StringBuilder(
				@"
            using System;
            namespace ExampleSourceGenerated
            {
                public static class ExampleSourceGenerated
                {
                    public static string GetTestText()
                    {
                        return ""This is from source generator 123");

			sourceBuilder.Append(System.DateTime.Now.ToString());

			sourceBuilder.Append(
				@""";
                    }
    }
}
");

			context.AddSource("exampleSourceGenerator", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
		}

		public void Initialize(GeneratorInitializationContext context)
		{
		}
	}
}