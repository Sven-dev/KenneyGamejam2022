using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private string UpgradeTag;
    [SerializeField] private Transform UpgradesTo;
    [Space]
    [SerializeField] private SpriteRenderer RequirementLabel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RequirementLabel.gameObject.SetActive(true);
        }
        else if (other.tag == UpgradeTag)
        {
            Upgrade();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            RequirementLabel.gameObject.SetActive(false);
        }
    }

    private void Upgrade()
    {
        Instantiate(UpgradesTo, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject);
    }
}
