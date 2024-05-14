using Microsoft.FeatureManagement;
using ResearchTBD.BranchByAbstraction.Branch;

namespace ResearchTBD.BranchByAbstraction;

public static class BranchByAbstractionExtensions
{
    public static IServiceCollection AddFeatureBranchs(this IServiceCollection services)
    {
        // register microsoft feature mangement
        services.AddFeatureManagement();

        services.AddBranchByAbstraction<IHelloWorldBranch, HelloWorldBranch, HelloNet8Branch>(
            FeatureNameConstants.HelloWorld
        );

        return services;
    }

    private static IServiceCollection AddBranchByAbstraction<
        TBranchInterface,
        TOriginBranch,
        TNextBranch
    >(this IServiceCollection services, string featureName)
        where TBranchInterface : IBranch
        where TOriginBranch : class, TBranchInterface
        where TNextBranch : class, TBranchInterface
    {
        services.AddTransient<TOriginBranch>();
        services.AddSingleton<Func<TOriginBranch>>(x => x.GetRequiredService<TOriginBranch>);

        services.AddTransient<TNextBranch>();
        services.AddSingleton<Func<TNextBranch>>(x => x.GetRequiredService<TNextBranch>);

        services.AddTransient<IBranchFactory<TBranchInterface>>(provider => new BranchFactory<
            TBranchInterface,
            TOriginBranch,
            TNextBranch
        >(
            provider.GetRequiredService<IFeatureManagerSnapshot>(),
            provider.GetRequiredService<Func<TOriginBranch>>(),
            provider.GetRequiredService<Func<TNextBranch>>(),
            featureName
        ));

        return services;
    }
}
