using VCardManager.Core.Abstractions;

namespace VCardManager.Tests._tools;

public class ConsoleSpy : IConsole
{
    private readonly Queue<string> _inputs = new();
    public List<string> Output = new();

    public void Write(string message) => Output.Add(message);
    public void WriteLine(string message) => Output.Add(message);
    public string ReadLine() => _inputs.Count > 0 ? _inputs.Dequeue() : string.Empty;

    //public void AddInput(string input) => _inputs.Enqueue(input);
    public void AddInput(params string[] input) => input.ToList().ForEach(_inputs.Enqueue);
}

