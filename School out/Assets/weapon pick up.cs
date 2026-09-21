using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string weaponName = "Sword";
    public int weaponDamage = 40;
    public GameObject weaponPrefab; // weapon model to equip

    private bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press E to pick up " + weaponName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            PickupWeapon();
        }
    }

    void PickupWeapon()
    {
        Playerattacksystem playerAttack = FindObjectOfType<Playerattacksystem>();

        if (playerAttack == null)
        {
            Debug.LogError("PlayerAttackSystem not found!");
            return;
        }

        // Set damage
        playerAttack.attackDamage = weaponDamage;

        // Equip weapon model
        Transform holder = playerAttack.transform.Find("WeaponHolder");
        if (holder != null)
        {
            GameObject weapon = Instantiate(weaponPrefab, holder);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }

        Debug.Log("Weapon equipped!");

        Destroy(gameObject);
    }
}