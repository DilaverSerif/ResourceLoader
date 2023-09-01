using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace ResourcesLoader
{
    public static class EnumCreator
    {
#if UNITY_EDITOR
        private static string EnumPath => ResourceStorage.Instance.ResourceLoadEnumsPath;
        private static string Tag => ResourceStorage.Instance.Enumtag;

        public static void GenerateEnumFile(this string[] values, string enumName)
        {
            var filePath = Path.Combine(EnumPath);
        
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"public enum {Tag}{enumName}");
                writer.WriteLine("{ None = -1,");

                for (var i = 0; i < values.Length; i++)
                    writer.WriteLine($"    {values[i]} = {i},");

                writer.WriteLine("}");
            }

            AssetDatabase.Refresh();
        }
    
        public static void GenerateEnumFile(this List<string> values, string enumName)
        {
            GenerateEnumFile(values.ToArray(),enumName);
        }

#endif
    }
}