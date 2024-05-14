using Microsoft.FeatureManagement;

namespace ResearchTBD.BranchByAbstraction;

public class BranchFactory<TBranchInterface, TOriginBranch, TNextBranch>
    : IBranchFactory<TBranchInterface>
    where TBranchInterface : IBranch
    where TOriginBranch : class, TBranchInterface
    where TNextBranch : class, TBranchInterface
{
    private readonly IFeatureManager _featureManger;

    private readonly Func<TOriginBranch> _originBranchFactory;
    private readonly Func<TNextBranch> _nextBranchFactory;

    private readonly string _featureName;

    public BranchFactory(
        IFeatureManager featureManger,
        Func<TOriginBranch> originBranchFactory,
        Func<TNextBranch> nextBranchFactory,
        string featureName
    )
    {
        _featureManger = featureManger;
        _originBranchFactory = originBranchFactory;
        _nextBranchFactory = nextBranchFactory;
        _featureName = featureName;
    }

    public async Task<TBranchInterface> Create()
    {
        return await _featureManger.IsEnabledAsync(_featureName)
            ? _nextBranchFactory()
            : _originBranchFactory();
    }
}
