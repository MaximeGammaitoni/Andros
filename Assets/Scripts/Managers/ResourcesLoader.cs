using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoader
{
    public CustomMaterials CustomMaterials;
    public Players Players;
    public Visualeffects Visualeffects;
    public ResourcesLoader()
    {
        Visualeffects = new Visualeffects();
    }
}
public class CustomMaterials
{

}
public class Players
{

}
public class Visualeffects
{
    public GameObject PlayerDeath;
}