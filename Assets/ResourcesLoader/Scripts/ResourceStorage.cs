using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ResourcesLoader
{
    [CreateAssetMenu(fileName = "ResourceStorage", menuName = "Resource Loader/ResourceStorage", order = 1)]
    public class ResourceStorage : ScriptableObject
    {
        public string Enumtag = "ResourcesLoad";
        public string StoragePath = "Loaded/";
        public Object ResourceLoadEnums;
        public string ResourceLoadEnumsPath => AssetDatabase.GetAssetPath(ResourceLoadEnums);
        public static ResourceStorage Instance
        {
            get
            { 
                return _instance ??= Resources.Load<ResourceStorage>(nameof(ResourceStorage));
            }
        }

        private static ResourceStorage _instance;
        public List<ResourceClass> resourceItems = new();


        [Serializable]
        public class ResourceClass
        {
            public string title;
            public List<ResourceItem> resourceItems = new();
        }

        public ResourceClass CheckFolderName(string folderName)
        {
            return resourceItems.FirstOrDefault(item => item.title == folderName);
        }
    
        public void ClearResourceItems()
        {
            resourceItems.Clear();
        }
    }
}