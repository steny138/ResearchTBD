using Microsoft.AspNetCore.Mvc;
using ResearchTBD.BranchByAbstraction;
using ResearchTBD.BranchByAbstraction.Branch;

namespace ResearchTBD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly IBranchFactory<IHelloWorldBranch> _branchFactory;

    public HelloWorldController(IBranchFactory<IHelloWorldBranch> branchFactory)
    {
        _branchFactory = branchFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var branch = await _branchFactory.Create();

        var returnValue = branch.Show();

        return Ok(returnValue);
    }
}
