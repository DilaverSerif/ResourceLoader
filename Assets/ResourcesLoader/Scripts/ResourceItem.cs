using System;
using Object = UnityEngine.Object;

namespace ResourcesLoader
{
    [Serializable]
    public struct ResourceItem
    {
        public Object prefab;
        public ResourcesLoad resourceItemEnum;
    
        public ResourceItem(Object prefab, ResourcesLoad resourceItemEnum)
        {
            this.prefab = prefab;
            this.resourceItemEnum = resourceItemEnum;
        }
    }
}