namespace ResearchTBD.BranchByAbstraction;

public interface IBranchFactory<TBranchInterface>
    where TBranchInterface : IBranch
{
    Task<TBranchInterface> Create();
}
