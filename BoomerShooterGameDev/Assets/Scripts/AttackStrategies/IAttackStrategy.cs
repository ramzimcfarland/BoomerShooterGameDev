public interface IAttackStrategy
{
    void Execute(WeaponCore weapon);
    bool CanAttack();
}
