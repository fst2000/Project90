public class WalkHumanMotion : IHumanMotion
{
    float IHumanMotion.MoveSpeed => 2f;
    float IHumanMotion.RotationSpeed => 180f;
}