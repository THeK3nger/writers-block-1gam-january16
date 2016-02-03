using UnityEngine;
using System.Collections;

public class Shaker : MonoBehaviour {

	public float ShakeAmount = 3.0f;
	private bool shaking = false;

    private Vector3 originalPosition;

    public void Shake(float duration)
    {
        if (shaking)
        {
            StopAllCoroutines();
            transform.position = originalPosition;
        }
        StartCoroutine(CoShake(duration));
    }

    IEnumerator CoShake(float duration)
    {
        shaking = true;
        float elapsed = 0.0f;
        originalPosition = transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= ShakeAmount * damper;
            y *= ShakeAmount * damper;

            transform.position = new Vector3(x, y, originalPosition.z);

            yield return null;
        }

        shaking = false;
        transform.position = originalPosition;
    }

}
