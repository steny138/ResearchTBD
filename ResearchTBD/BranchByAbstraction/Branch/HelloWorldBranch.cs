namespace ResearchTBD.BranchByAbstraction.Branch;

public interface IHelloWorldBranch : IBranch
{
    string Show();
}

public class HelloWorldBranch : IHelloWorldBranch
{
    public string Show()
    {
        return "Hello World.";
    }
}

public class HelloNet8Branch : IHelloWorldBranch
{
    public string Show()
    {
        return "Hello .Net 8.";
    }
}
