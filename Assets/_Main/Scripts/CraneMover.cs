using UnityEngine;

public class CraneMover : MonoBehaviour
{
    public float speed = 3f;
    public float limitX = 2.5f;

    float input = 0f;

    void Update()
    {
        Vector3 pos = transform.localPosition;

        pos.x += input * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);

        transform.localPosition = pos;
    }

    public void SetInput(float direction)
    {
        input = direction;
    }
}