using UnityEngine;

public class CurrentPlayerCharacter : MonoBehaviour
{
    GameObject Player;
    public CurrentCharacter CurrentCharacter;

    [SerializeField] OverAllStat stat;
    private void Awake()
    {
        ResetStat();
        Player = CurrentCharacter.CharacterUse.CharacterPreFab;
        GameObject player = Instantiate(Player, this.transform.position, Quaternion.identity);

        FindObjectOfType<Walk>().GetCharacter(CurrentCharacter.CharacterUse);
        FindObjectOfType<PlayerHealth>().GetCharacter(CurrentCharacter.CharacterUse);
    }

    public void ResetStat()
    {
     stat.CurrentHealth = 0;
    stat.CurrentArmor = 0;
        stat.Ammo = 0; // PlusAmmo 
        stat.AttackSpeed = 0;
        stat.WalkSpeed =0; //SpaceShip WalkSpeed;
        stat.BulletSpeed = 0; // * Percent
        stat.BulletPiercing = 0; // * Percent
        stat.BulletDamage = 0; // * Percent
        stat.PickUpRange = 0; // * Percent
        stat.ReloadSpeed = 0;

}
    
}

