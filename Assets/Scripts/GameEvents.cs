using AI;

public class GameEvents
{
    public struct OnEntityDestroy
    {
        public GroupAI.Type typeKilled;
        public GroupAI.Type killedBy;
    }
    
    public struct OnGameOver
    {
        public GroupAI.Type loser;
    }
}