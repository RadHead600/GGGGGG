public class UpgradeAddWallHealthPoints : UpgradeAddHealthPoints
{
    protected override void Awake()
    {
        UpgradeId = 2;
        base.Awake();
        Level = GameInformation.Instance.Information.UpgradesLevel[UpgradeId];
    }
}
