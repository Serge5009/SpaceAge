using UnityEngine;

[CreateAssetMenu(fileName = "New resource", menuName = "Economy/Resources")]
public class ResourceData : ScriptableObject
{
    public RES resID;
    public string resName;
    public Sprite resImage;
    public bool isBasicRes;
}
