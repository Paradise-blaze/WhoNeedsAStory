using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public Weapon currentWeapon;

    // Start is called before the first frame update
    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        //damage = myStats.damage.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
