using UnityEngine;

public class Hand : MonoBehaviour
{
    public Weapon Weapon { get; private set; }

    private void Start()
    {
        Weapon = FindWeapon();
    }

    public void SetHandWeapon(Weapon weapon)
    {
        Weapon = weapon;
    }

    public Weapon FindWeapon()
    {
        return GetComponentInChildren<Weapon>();
    }
}
