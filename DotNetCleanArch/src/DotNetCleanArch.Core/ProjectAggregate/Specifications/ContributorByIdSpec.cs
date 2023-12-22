using Ardalis.Specification;
using DotNetCleanArch.Core.ContributorAggregate;

namespace DotNetCleanArch.Core.ProjectAggregate.Specifications;

public class ContributorByIdSpec : Specification<Contributor>, ISingleResultSpecification
{
  public ContributorByIdSpec(int contributorId)
  {
    Query
        .Where(contributor => contributor.Id == contributorId);
  }
}
