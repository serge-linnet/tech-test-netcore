# 2,3,4,6

Those were trivial, so I didn't write any notes.

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
- Use DisplayName in TodoList/Details

# 9 Create Todo Item with a Modal

 Started with extracting TodoItem\Create view into a ViewComponent and wrapping it into a bootstrap modal. This had a couple of issues:

- Saving the todo item triggers page reload.
- Server validation doesn't work - it just returns missing Create view. So I added native HTML "required" attribute for the todo item title. Which did the job.

As part of this task I removed dbContext as a dependency in the views and instead included Responsible Parties as part of the model.

I also made some service methods and controller actions asynchronous.

My main struggle was using Razor and trying to do a REST API approach. I looked into Microsoft.jQuery.Unobtrusive.Ajax, but it's deprecated. For this kind of task I would use jQuery in the past, but now I would look into Vue, for example, as it is a progressive framework and can be used in parts of the web application. Going with Vue would take more initially then using jQuery, but would allow implementing filtering and ranking UX much faster and smoother.