using UnityEngine;

public class UI_CraneInput : MonoBehaviour
{
    public CraneMover crane;

    public void MoveLeft()
    {
        crane.SetInput(-1f);
    }

    public void MoveRight()
    {
        crane.SetInput(1f);
    }

    public void StopMove()
    {
        crane.SetInput(0f);
    }
}