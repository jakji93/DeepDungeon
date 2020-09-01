namespace Game.Runes
{
    public interface IRune
    {
        int GetCost();
        bool GetIsBuffRune();
        void DestroyRune();
    } 
}
