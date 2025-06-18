using UnityEngine;

namespace Domir.Client.Core.Messages
{
    public readonly struct MoveStartedMessage
    {
        public Vector2 Direction { get; }

        public MoveStartedMessage(Vector2 direction)
        {
            Direction = direction;
        }
    }

    public readonly struct MovePerformedMessage
    {
        public Vector2 Direction { get; }

        public MovePerformedMessage(Vector2 direction)
        {
            Direction = direction;
        }
    }

    public readonly struct MoveCanceledMessage
    {
        public Vector2 Direction { get; }

        public MoveCanceledMessage(Vector2 direction)
        {
            Direction = direction;
        }
    }
}