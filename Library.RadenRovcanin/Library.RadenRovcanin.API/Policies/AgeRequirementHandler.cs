using Microsoft.AspNetCore.Authorization;

namespace Library.RadenRovcanin.API.Policies
{
    public class AgeRequirementHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            if (!context.User.HasClaim(claim => claim.Type == "Age"))
            {
                return Task.CompletedTask;
            }

            int actualAge = int.Parse(s: context.User.FindFirst(claim => claim.Type == "Age").Value);

            if (actualAge >= requirement.Age)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
