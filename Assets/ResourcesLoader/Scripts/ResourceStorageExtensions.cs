using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ResourcesLoader
{
    public static class ResourceStorageExtensions
    {
        public static T GetResource<T>(this ResourcesLoad storage) where T : Object
        {
            var name = storage.ToString().Split('_');
            var selectFolder = ResourceStorage.Instance.
                resourceItems.Where(x => x.title == name[0]);
        
            return selectFolder.SelectMany(item => item.resourceItems).
                FirstOrDefault(item => item.resourceItemEnum == storage).prefab as T;
        }
    
        public static GameObject GetSourceGameObject (this ResourcesLoad storage)
        {
            var name = storage.ToString().Split('_');
            var selectFolder = ResourceStorage.Instance.
                resourceItems.Where(x => x.title == name[0]);
            
            return selectFolder.SelectMany(item => item.resourceItems).
                FirstOrDefault(item => item.resourceItemEnum == storage).prefab as GameObject;
        }
        
        public static T Instantiate <T>(this ResourcesLoad storage,Vector3 position = default, Quaternion rotation = default, Transform parent = null) where T : Object
        {
            return Object.Instantiate(storage.GetResource<T>(),position,rotation,parent);
        }
        
        public static GameObject Instantiate (this ResourcesLoad storage,Vector3 position = default, Quaternion rotation = default, Transform parent = null)
        {
            return Object.Instantiate(storage.GetSourceGameObject(),position,rotation,parent);
        }
    }
}