using UnityEngine;
using System.Collections;

public class CraneController : MonoBehaviour
{
    public Transform claw;
    public float dropDistance = 4f;
    public float dropSpeed = 5f;
    public float liftSpeed = 5f;

    public ClawGrabber grabber;

    bool busy;

    public void Grab()
    {
        if (!busy)
            StartCoroutine(DropRoutine());
    }

    IEnumerator DropRoutine()
    {
        busy = true;

        Vector3 startPos = claw.localPosition;
        Vector3 target = startPos + Vector3.down * dropDistance;

        // turun
        while (Vector3.Distance(claw.localPosition, target) > 0.01f)
        {
            claw.localPosition = Vector3.MoveTowards(
                claw.localPosition,
                target,
                dropSpeed * Time.deltaTime
            );
            yield return null;
        }

        // tutup claw
        grabber.CloseClaw();

        yield return new WaitForSeconds(0.5f);

        // naik kembali
        while (Vector3.Distance(claw.localPosition, startPos) > 0.01f)
        {
            claw.localPosition = Vector3.MoveTowards(
                claw.localPosition,
                startPos,
                liftSpeed * Time.deltaTime
            );
            yield return null;
        }

        // buka claw
        grabber.OpenClaw();

        busy = false;
    }
}