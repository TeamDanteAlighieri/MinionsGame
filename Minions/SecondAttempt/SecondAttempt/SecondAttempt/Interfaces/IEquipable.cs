namespace SecondAttempt
{
    /// <summary>
    /// Used by equipment items. Can be expanded to cosmetic items.
    /// </summary>
    public interface IEquipable
    {
        void Equip(Minion target);

        void Unequip(Minion target);
    }
}
