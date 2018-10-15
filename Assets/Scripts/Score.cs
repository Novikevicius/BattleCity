
namespace BattleCity.Miscellaneous
{
    public sealed class Score
    {
        public int KilledBasicTanksCount { get; private set; }
        public int KilledFastTanksCount  { get; private set; }
        public int KilledPowerTanksCount { get; private set; }
        public int KilledArmorTanksCount { get; private set; }
        public int score { get; private set; }

        public void AddBasicTank()
        {
            KilledBasicTanksCount++;
            score += 100;
        }
        public void AddFastTank()
        {
            KilledFastTanksCount++;
            score += 200;
        }
        public void AddPowerTank()
        {
            KilledPowerTanksCount++;
            score += 300;
        }
        public void AddArmorTank()
        {
            KilledPowerTanksCount++;
            score += 400;
        }
        public void AddPowerUp()
        {
            KilledPowerTanksCount++;
            score += 500;
        }
    }
}
