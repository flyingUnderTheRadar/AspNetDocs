 [HttpPost]
 [AllowAnonymous]
 [ValidateAntiForgeryToken]
public async Task<ActionResult> Register(RegisterViewModel model)
{
    if (ModelState.IsValid)
    {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await UserManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
             await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);
                    
             // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
             // Send an email with this link
             // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
             // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
             // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

             return RedirectToAction("Index", "Home");
         }
         AddErrors(result);
     }

    // If we got this far, something failed, redisplay form
     return View(model);
 }