using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ResourcesLoader
{
    public static class ResourceLoaderEditor
    {
#if UNITY_EDITOR
        class ResourceItemData
        {
            public List<Object> prefabList = new List<Object>();
            public string folderName;

            public ResourceItemData(Object prefab, string folderName)
            {
                if (!prefabList.Contains(prefab))
                {
                    prefabList.Add(prefab);
                    this.folderName = folderName;
                }
            }

            public string EnumName(int index)
            {
                return folderName + "_" + prefabList[index].name;
            }

            public string[] EnumNameArray()
            {
                var array = new string[prefabList.Count];
                for (var i = 0; i < prefabList.Count; i++)
                    array[i] = folderName+"_"+prefabList[i].name;
                return array;
            }
        }
    
    
        [MenuItem("Tools/Resource Loader/Open Storage")]
        public static void CreateResourceStorage()
        {
            var path = AssetDatabase.GetAssetPath(ResourceStorage.Instance);
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    
        [MenuItem("Tools/Resource Loader/Get Resource")]
        public static void GetResources()
        {
            ResourceStorage.Instance.ClearResourceItems();
            if (File.Exists(ResourceStorage.Instance.ResourceLoadEnumsPath))
                File.WriteAllText(ResourceStorage.Instance.ResourceLoadEnumsPath, string.Empty);
        
            var resourceStorage = ResourceStorage.Instance;
            var path = Resources.LoadAll(resourceStorage.StoragePath);
            // var dataList = new List<ResourceItemData>();
            var objects = new List<string>();
        
            foreach (Object o in path)
            {
                var assetPath = AssetDatabase.GetAssetPath(o);
                string[] pathParts = assetPath.Split(new[] { "Resources/" }, StringSplitOptions.None);

                if (pathParts.Length > 1)
                {
                    string resourcesPath = pathParts[1]; // "Loaded/Basic/"
                    string[] subfolderNames = resourcesPath.Split('/');
                
                    var folderName = "Main";
                    if (subfolderNames.Length > 2)
                        folderName = subfolderNames[^2];
                
                
                    objects.Add(folderName+"_"+o.name);

                    var folder = ResourceStorage.Instance.CheckFolderName(folderName);
                    if (folder != null)
                    {
                        var tryEnum = Enum.Parse<ResourcesLoad>(folderName + "_" + o.name);
                        folder.resourceItems.Add(new ResourceItem(o,tryEnum));
                    }
                    else
                    {
                        var tryEnum = Enum.Parse<ResourcesLoad>(folderName + "_" + o.name);
                        var newClass = new ResourceStorage.ResourceClass();
                        newClass.resourceItems.Add(new ResourceItem(o,tryEnum));
                        newClass.title = folderName;
                    
                        ResourceStorage.Instance.resourceItems.Add(newClass);
                    }
                
                    // if (dataList.Any(item => item.folderName == folderName))
                    //     dataList.First(item => item.folderName == folderName).prefabList.Add(o);
                    // else
                    //     dataList.Add(new ResourceItemData(o, folderName));
                }
            }
        
            objects.GenerateEnumFile("");
        }
#endif
    }
}