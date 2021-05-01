using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Factory/ResourcesLoaderManagerFactory", order = 1)]
public class PrefabsLoaderManagerFactory : ScriptableObject, IFactory<PrefabsLoaderManager>
{
    public VFXLoader VFXLoader;
    public EnnemiesLoader EnnemiesLoader;
    public PrefabsLoaderManager Create()
    {
        var rlm = new PrefabsLoaderManager();
        rlm.VFXLoader = VFXLoader;
        rlm.EnnemiesLoader = EnnemiesLoader;
        return rlm;
    }
}
