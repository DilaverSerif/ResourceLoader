# ResourceLoader
It enables objects in the resource folder to access their references on enums.

Example
```csharp
    private IEnumerator Start()
    {
        ResourcesLoad.Basic_Capsule.Instantiate(new Vector3(0,10,0));
        yield return new WaitForSeconds(1);
        ResourcesLoad.Basic_Cube.Instantiate(new Vector3(0,10,0));
    }
}
```

------------

Guid

1. You must put files in location : Resource/Loaded
2. Then you go Tools/ResourceLoader/GetSources
<img src="https://i.imgur.com/g6xI1kk.png" width="450" height="200" />




##### Then, should look like this

<img src="https://i.imgur.com/ocQzrF9.png" width="450" height="800" />

------------


> Enum be like this: Foldername_Objectname
