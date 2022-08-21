using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveManager : MonoBehaviour
{
    [SerializeField] private float EnvironmentRange = 1;
    [Space]
    [Range(0, 0.1f)]
    [SerializeField] private float MaterialPenalty = 0.025f;
    [Range(0, 0.1f)]
    [SerializeField] private float BrokenPenalty = 0.1f;
    [Range(0, 0.1f)]
    [SerializeField] private float Tier2Bonus = 0.025f;
    [Range(0, 0.1f)]
    [SerializeField] private float Tier3Bonus = 0.1f;
    [Space]
    [SerializeField] private Transform WoodPrefab;
    [SerializeField] private Transform StonePrefab;
    [SerializeField] private Transform IronPrefab;
    [Space]
    [SerializeField] private Transform RewardPivot;
    [SerializeField] private Transform Zombie;

    private int BaseValue = 100;
    private float EnvironmentModifier = 1f;

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
            yield return new WaitForSeconds(5);

            print("Started spherecast");

            //Get all carryable objects in a radius around the zombie
            Ray ray = new Ray(Zombie.position, Vector3.forward);
            LayerMask mask = LayerMask.GetMask("Carryable");
            RaycastHit[] objects = Physics.SphereCastAll(ray, EnvironmentRange, 100, mask);

            Debug.DrawRay(Zombie.position, Vector3.forward * EnvironmentRange, Color.red, 5f);
            Debug.DrawRay(Zombie.position, Vector3.back * EnvironmentRange, Color.red, 5f);
            Debug.DrawRay(Zombie.position, Vector3.left * EnvironmentRange, Color.red, 5f);
            Debug.DrawRay(Zombie.position, Vector3.right * EnvironmentRange, Color.red, 5f);

            EnvironmentModifier = 1f;
            foreach(RaycastHit carryable in objects)
            {
                print("Found: " + carryable.transform.name);

                if (carryable.transform.tag == "Wood" ||
                    carryable.transform.tag == "Stone" ||
                    carryable.transform.tag == "Iron")
                {
                    print("Material :(");
                    EnvironmentModifier -= MaterialPenalty;
                }
                else if (carryable.transform.tag == "Broken")
                {
                    print("Broken :(");
                    EnvironmentModifier -= BrokenPenalty;
                }
                else if (carryable.transform.tag == "Tier2")
                {
                    print("Tier 2 :)");
                    EnvironmentModifier += Tier2Bonus;
                }
                else if (carryable.transform.tag == "Tier3")
                {
                    print("Tier 3 :)");
                    EnvironmentModifier += Tier3Bonus;
                }
            }

            //gain money
            int money = (int)(BaseValue * EnvironmentModifier);

            print(transform.name + " value: " + money);
            if (money >= 200)
            {
                print("Earned: iron");
                SpawnReward(IronPrefab);
            }
            else if (money >= 150)
            {
                print("Earned: stone");
                SpawnReward(StonePrefab);
            }
            else if (money >= 100)
            {
                print("Earned: wood");
                SpawnReward(WoodPrefab);
            }
            else
            {
                print("Earned: nothing");
            }

            print("_________________________________________________________________________");
        }
    }

    private void SpawnReward(Transform Reward)
    {
        Instantiate(Reward, RewardPivot.position, Quaternion.identity, RewardPivot);
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
