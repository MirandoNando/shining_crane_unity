using UnityEngine;

public class CraneMover : MonoBehaviour
{
    public float speed = 5f;
    public float limitX = 3.5f;

    float input;

    void Update()
    {
        float move = input * speed * Time.deltaTime;

        Vector3 pos = transform.localPosition;
        pos.x = Mathf.Clamp(pos.x + move, -limitX, limitX);

        transform.localPosition = pos;
    }

    public void SetInput(float value)
    {
        input = value;
    }
}