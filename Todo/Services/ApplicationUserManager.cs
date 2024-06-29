using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Data.Entities;
using Todo.Models.Identity;

namespace Todo.Services
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        private readonly IGravatarProfileService _gravatarProfileService;

        public ApplicationUserManager(
            IGravatarProfileService gravatarProfileService,
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger) :
            base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _gravatarProfileService = gravatarProfileService;
        }

        public async override Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            if (string.IsNullOrWhiteSpace(user.DisplayName))
            {
                try
                {
                    user.DisplayName = await _gravatarProfileService.GetUserName(user.Email);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "Failed to get username from Gravatar");
                }
            }

            return await base.CreateAsync(user);
        }
    }
}
