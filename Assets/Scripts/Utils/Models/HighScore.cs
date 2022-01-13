using System;

public class HighScore
{
    public int Id { get; set; }
    public int Score { get; set; }
    public Guid GameId { get; set; }
    public string GameName { get; set; }
}