using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveManager : MonoBehaviour
{
    [SerializeField] private Transform Zombie;

    private int BaseValue = 100;
    private float GravestoneModifier = 0.25f;
    private float LightModifier = 0.5f;
    private float EnvironmentModifier = 0.1f;

    private List<Transform> EnvironmentObjects = new List<Transform>();

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(_SpawnZombie());
        StartCoroutine(_IncomeLoop());
    }

    private void Update()
    {
        //Raycast above grave to see what tier gravestone is there (limited range)
    }

    private IEnumerator _IncomeLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            //gain money
            int money = (int)(BaseValue * GravestoneModifier * LightModifier * EnvironmentModifier);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
