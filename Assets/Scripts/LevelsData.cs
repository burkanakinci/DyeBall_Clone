using UnityEngine;

[CreateAssetMenu(fileName = "LevelsData", menuName = "Levels Data")]
public class LevelsData : ScriptableObject
{
    public Transform[] ballTransforms;
    public Transform[] bodyTransforms;
    public Transform[] wallTransforms;
    public void SpawnLevel()
    {
        MapGenerate.Instance.SpawnBall(Vector3.zero);
    }

}
