using Grpc.Core;
using BcProto.gRPC;
using static BcProto.gRPC.BadgerClanServiceProto;


namespace BadgerClan.gRPC.Services;
public class BadgerClanService(ILogger<BadgerClanService> logger) : BadgerClanServiceProtoBase
{
    public override async Task<StatusMessage> AddMoves(Moves request, ServerCallContext context)
    {
        if (request.Success == STATUS.Success)
        {
            foreach (var move in request.MoveList)
            {
                var moveValue = new Move()
                {
                    Movement = MOVE_TYPE.
                };
            }
        }
    }
}
