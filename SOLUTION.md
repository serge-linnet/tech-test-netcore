# 8 Gravatar Profile Info

I was thinking about few options:

- Fetch profile on frontend.
- Add an API that would return display name for the user, but would fetch it from Gravatar on every call. 
- Enrich identity record with profile info on registration. 

Name is displayed on every page, so on every load we'd have to ping Gravatar. We would hit the request limit very soon, it would also slow down page load. So I decided to go with the last option, although it required additional changes.

- Extended UserManager -> ApplicationUserManager with extra step in Create.
- Extended IdentityUser -> ApplicationUser with DisplayName.
- Created EF Migration for DisplayName.
- Updated Startup identiy config.
- Created GravatarProfileService for communication with their API.