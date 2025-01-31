using BadgerClan.Logic;

namespace BadgerClanApi.Pathing
{
    public class Sacrifice : IPath
    {
        public Task<List<Move>> GetMovesAsync(MoveRequest request)
        {
            var units = request.Units.Where(u => u.Team == request.YourTeamId);
            var moves = new List<Move>();
            int onlyTakesOne = 0;

            foreach (var unit in units)
            {
                var enemies = request.Units.Where(u => u.Team != request.YourTeamId);
                var closest = enemies.OrderBy(u => u.Location.Distance(unit.Location)).FirstOrDefault();
                if (closest != null && onlyTakesOne == 0 && unit.Type == "Knight"
                    && closest.Location.Distance(unit.Location) > closest.AttackDistance + 1)
                {
                    moves.Add(new Move(MoveType.Walk, unit.Id, unit.Location.Toward(closest.Location)));
                    onlyTakesOne = 1;
                }
                else
                {
                    moves.Add(new Move(MoveType.Walk, unit.Id, unit.Location.Away(closest.Location)));
                }
            }
            onlyTakesOne = 0;
            return Task.FromResult(moves);
        }
    }
}
