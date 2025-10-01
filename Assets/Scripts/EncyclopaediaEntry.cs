using UnityEngine;

[CreateAssetMenu(menuName = "Encyclopaedia/Entry", fileName = "NewEntry")]
public class EncyclopaediaEntry : ScriptableObject
{
    public string title;

    [TextArea(3, 10)] public string description;
    [TextArea] public string tryItOutDescription;
    public string formulaTitle;

    public Sprite formulaImage;
    public Sprite realImage;
    public Sprite simImage;
}
