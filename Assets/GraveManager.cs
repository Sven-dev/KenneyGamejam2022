using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveManager : MonoBehaviour
{
    [SerializeField] private Transform Zombie;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_SpawnZombie());
    }

    private IEnumerator _SpawnZombie()
    {
        yield return new WaitForSeconds(5f);
        float progress = 0;
        while (progress < 1)
        {
            progress += Time.deltaTime / 20;

            Zombie.localRotation = Quaternion.Lerp(Quaternion.Euler(Vector3.right * 180), Quaternion.Euler(Vector3.zero), progress);
            yield return null;
        }
    }
}
