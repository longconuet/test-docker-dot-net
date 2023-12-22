using Ardalis.Result;

namespace DotNetCleanArch.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(int contributorId);
}
