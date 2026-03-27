using UnityEngine;

public class ClawGrabber : MonoBehaviour
{
    public Transform holdPoint;

    GameObject grabbed;

    public void CloseClaw()
    {
        Collider[] hits = Physics.OverlapSphere(
            holdPoint.position,
            0.3f
        );

        foreach (Collider col in hits)
        {
            if (col.CompareTag("Prize"))
            {
                grabbed = col.gameObject;

                grabbed.GetComponent<Rigidbody>().isKinematic = true;

                grabbed.transform.SetParent(holdPoint);
                grabbed.transform.localPosition = Vector3.zero;

                break;
            }
        }
    }

    public void OpenClaw()
    {
        if (grabbed == null) return;

        grabbed.transform.SetParent(null);

        Rigidbody rb = grabbed.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        grabbed = null;
    }
}