using AI;

public class GameEvents
{
    public struct OnEntityDestroy
    {
        public GroupAI.Type typeKilled;
        public GroupAI.Type killedBy;
    }
}