using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Staffs
{
    public class AddModel : SysPageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;


        public AddModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;

            _userManager = userManager;
        }
        [BindProperty]
        public Staff Staff { get; set; }





        public void OnGet()
        {
            Title = PageTitle = "Add new Staff ";

        }
        public async Task<IActionResult> OnPost()
        {

            Staff.Id = Guid.NewGuid();
            Staff.CreatorId = CurrentUserId;
            Staff.CreationDate = DateTime.UtcNow;

            var newuser = new User
            {
                Id = Guid.NewGuid(),
                Name = Staff.Fullname,
                Email = Staff.Email.ToLower().Trim(),
                LoginId = Staff.Email.ToLower().Trim(),
                CreationDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                IsActive = true,
                IsEmailConfirmed = true,

                ActivationDate = DateTime.Now,

                StaffId = Staff.Id,


            };
            await Db.User.AddAsync(newuser);
            newuser.PasswordHash = _userManager.PasswordHasher.HashPassword(newuser, "Staff");
            await Db.Staff.AddAsync(Staff);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { Staff.Id }); 
        }
    }

}


