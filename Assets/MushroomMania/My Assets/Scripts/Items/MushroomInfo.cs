using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[CreateAssetMenu(fileName = "MushroomInfo", menuName = "Data/MushroomInfo")]
public class MushroomInfo : ScriptableGameObject
{
    public string Name;
    public string CapInfo;
    public string GillsPores;
    public string GillsPoresInfo;
    public string StemInfo;
    public string RingInfo;
    public string VolvaInfo;
    public string Edibility;


    public void Copy(MushroomInfo other)
    {
        this.Name = other.Name;
        this.CapInfo = other.CapInfo;
        this.GillsPores = other.GillsPores;
        this.GillsPoresInfo = other.GillsPoresInfo;
        this.StemInfo = other.StemInfo;
        this.RingInfo = other.RingInfo;
        this.VolvaInfo = other.VolvaInfo;
        this.Edibility = other.Edibility;
    }
}
