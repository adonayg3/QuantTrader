namespace QuantTrader.Entities.CoinData;

public class CoinDeveloperData
{
    public long? Forks { get; set; }
    public long? Stars { get; set; }
    public long? Subscribers { get; set; }
    public long? TotalIssues { get; set; }
    public long? ClosedIssues { get; set; }
    public long? PullRequestsMerged { get; set; }
    public long? PullRequestContributors { get; set; }
    public Dictionary<string,long?> CodeAdditionsDeletions4Weeks { get; set; }
    public long? CommitCount4Weeks { get; set; }
    public long[] Last4WeeksCommitActivitySeries { get;set; }
}