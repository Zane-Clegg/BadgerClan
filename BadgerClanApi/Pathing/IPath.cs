using BadgerClan.Logic;

namespace BadgerClanApi.Pathing
{
    public interface IPath
    {
        public Task<List<Move>> GetMovesAsync(MoveRequest request);
    }
}
