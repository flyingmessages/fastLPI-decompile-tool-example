using System;

using fastLPI.tools.decompiler.data;
using fastLPI.tools.decompiler.data.digest;
using fastLPI.tools.decompiler.helper;

namespace fastLPI.tools.decompiler
{
    public class Program
    {
        // Util.GetLokationFolder() - returns the path to the current working directory.
        // PathIn - path to jar library (core.jar - processing 3 core for example).
        // PathTo - path for decompiled code.

        public static readonly string PathIn = $@"{Util.GetLokationFolder()}\core.jar";
        public static readonly string PathTo = $@"{Util.GetLokationFolder()}\CoreExtract";

        public static void Main(string[] args)
        {
            // JD_CLI_JavaDecompiler example
            JD_CLI_JavaDecompiler decompiler = new JD_CLI_JavaDecompiler(PathIn, PathTo);
            decompiler.Properties.SkipResources = true; // we can skip resource decompilation when decompiling.
            decompiler.Properties.OutputType = OutputType.Dir; // output code type (Folder or archive)
            decompiler.Properties.LogLevel = LogLevel.INFO; // CLI log level.
            decompiler.CreateNoWindow = false;
            decompiler.Decompile(true); // true - decompile file with replacement

            // We display the data received from the decompiler.
            Console.WriteLine(decompiler.DecompilerProcessReaderOutputData);
            Console.ReadKey();
            Console.Clear();

            // JarDataLoader example
            JarDataLoader dataLoader = new JarDataLoader(PathIn);
            dataLoader.Load(); // load jar and convert its content to xml content.
            dataLoader.LoadJarDataContentFromXmlResult(); // load xml content.
            dataLoader.PrintInfo(); // output information about the jar library to the console.

            // JarFileDigest example
            JarFileDigest digest = new JarFileDigest(dataLoader.Document.ChildItems);
            digest.PrintDigest(); // output to the console a list of all elements of the library.

            Console.WriteLine("\n" + dataLoader.Document.DocumentProperties.DocumentName);
            Console.WriteLine(dataLoader.Document.DocumentProperties.DocumentItemsFullLength);

            Console.ReadKey();
        }
    }
}
