public class UpgradeAddPlayerHealthPoints : UpgradeAddHealthPoints
{
    protected override void Awake()
    {
        int initialUpgradeId = 0;
        
        UpgradeId = initialUpgradeId;
        base.Awake();
        Level = GameInformation.Instance.Information.UpgradesLevel[UpgradeId];
    }
}
