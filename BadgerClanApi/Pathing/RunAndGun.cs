using BadgerClan.Logic.Bot;
using BadgerClan.Logic;

namespace BadgerClanApi.Pathing
{
    public class RunAndGun : IPath
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
                    if (closest.Location.Distance(unit.Location) <= unit.AttackDistance)
                    {
                        moves.Add(new Move(MoveType.Attack, unit.Id, closest.Location));
                    }
                    else if (request.Medpacs > 0 && unit.Health < unit.MaxHealth)
                    {
                        moves.Add(new Move(MoveType.Medpac, unit.Id, unit.Location));
                    }
                    else
                    {
                        moves.Add(new Move(MoveType.Walk,unit.Id, unit.Location.Toward(closest.Location)));
                    }
                }
            }
            return Task.FromResult(moves);
        }
    }
}
