using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeEffect : MonoBehaviour
{
    public float earthquakeIntensity = 0.1f; 
    public float minFrequency = 5.0f; 
    public float maxFrequency = 10.0f; 
    public float shakeDuration = 1.0f; 

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(StartRandomEarthquake()); // Start Random
    }

    IEnumerator StartRandomEarthquake()
    {
        while (true) // Loop
        {

            float timeUntilNextShake = Random.Range(minFrequency, maxFrequency);

            // Wait until the random time arrives.
            yield return new WaitForSeconds(timeUntilNextShake);

            // �����������
            StartCoroutine(ShakeGround());
        }
    }

    IEnumerator ShakeGround()
    {
        float elapsedTime = 0.0f;

        // �ӡ����蹨����ҨФú duration ����˹�
        while (elapsedTime < shakeDuration)
        {
            // �����������᡹ X ��� Z
            float xShake = Random.Range(-1f, 1f) * earthquakeIntensity;
            float zShake = Random.Range(-1f, 1f) * earthquakeIntensity;

            // ����¹���˹��ѵ�� (��鹼��)
            transform.position = new Vector3(originalPosition.x + xShake, originalPosition.y, originalPosition.z + zShake);

            // ����������ҷ���ҹ�
            elapsedTime += Time.deltaTime;

            // �ͨ��֧����Ѵ�
            yield return null;
        }

        // ��ѧ�ҡ����������������Ѻ��ѧ���˹��������
        transform.position = originalPosition;
    }
}
