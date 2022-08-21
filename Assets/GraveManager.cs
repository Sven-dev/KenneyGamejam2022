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
    [Space]
    [SerializeField] private SpriteRenderer MoodLabel;
    [SerializeField] private Sprite UnhappySprite;
    [SerializeField] private Sprite NeutralSprite;
    [SerializeField] private Sprite HappySprite;
    [SerializeField] private Sprite PerfectSprite;

    private int BaseValue = 100;
    private float EnvironmentModifier = 1f;

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
        yield return new WaitForSeconds(25);

        while (true)
        {
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
                    EnvironmentModifier -= MaterialPenalty;
                }
                else if (carryable.transform.tag == "Broken")
                {
                    EnvironmentModifier -= BrokenPenalty;
                }
                else if (carryable.transform.tag == "Tier2")
                {
                    EnvironmentModifier += Tier2Bonus;
                }
                else if (carryable.transform.tag == "Tier3")
                {
                    EnvironmentModifier += Tier3Bonus;
                }
            }

            //gain money
            int money = (int)(BaseValue * EnvironmentModifier);

            if (money >= 150)
            {
                SpawnReward(IronPrefab);
                MoodLabel.sprite = PerfectSprite;
            }
            else if (money >= 125)
            {
                SpawnReward(StonePrefab);
                MoodLabel.sprite = HappySprite;
            }
            else if (money >= 100)
            {
                SpawnReward(WoodPrefab);
                MoodLabel.sprite = NeutralSprite;
            }
            else
            {
                MoodLabel.sprite = UnhappySprite;
            }

            yield return new WaitForSeconds(60);
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
