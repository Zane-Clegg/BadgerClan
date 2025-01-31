using BadgerClan.Logic;

namespace BadgerClanApi.Pathing
{
    public class RunAway : IPath
    {
        public Task<List<Move>> GetMovesAsync(MoveRequest request)
        {
            var units = request.Units.Where(u => u.Team == request.YourTeamId);
            var moves = new List<Move>();

            foreach (var unit in units)
            {
                var enemies = request.Units.Where(u => u.Team != request.YourTeamId);
                var closest = enemies.OrderBy(u => u.Location.Distance(unit.Location)).FirstOrDefault();
                if (closest != null)
                {
                    moves.Add(new Move(MoveType.Walk, unit.Id, unit.Location.Away(closest.Location)));
                }
            }
            return Task.FromResult(moves);
        }
    }
}

