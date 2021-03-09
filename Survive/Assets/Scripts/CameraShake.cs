using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float time = 0;
    private Vector3 cameraPos;
    public IEnumerator ShakeCamera(float timeShake, float magnitude)
    {
        cameraPos = transform.position;

        while (time < timeShake)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, 0);

            time += Time.deltaTime;

            yield return null;
        }

        time = 0;

        transform.position = cameraPos;
    }
}
