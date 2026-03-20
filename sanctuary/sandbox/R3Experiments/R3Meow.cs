using System;
using Godot;

public partial class R3Meow : Node
{
    IDisposable subscription;

    public override void _Ready()
    {
        subscription = Observable
            .EveryUpdate()
            .ThrottleLastFrame(10)
            .Subscribe(x =>
            {
                GD.Print($"Observable.EveryUpdate: {GodotFrameProvider.Process.GetFrameCount()}");
            });
    }

    public override void _ExitTree()
    {
        subscription?.Dispose();
    }
}
