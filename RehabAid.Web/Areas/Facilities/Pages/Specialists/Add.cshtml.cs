using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehabAid.Data;
using RehabAid.Web.Pages;
using System.Threading.Tasks;
using System;
using System.IO;
using wCyber.Helpers.Web;
using RehabAid.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehabAid.Lib;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace RehabAid.Web.Areas.Facilities.Pages.Specialists
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
        public Specialist Specialist { get; set; }
       
        public SelectList Specialty { get; set; }

       
        
        public void OnGet()
        {
            Title = PageTitle = "Add new Specialist ";
            Specialty = new SelectList(Enum.GetValues(typeof(SpecialtyType))
                           .Cast<SpecialtyType>()
                            .Select(ft => new SelectListItem
                           {
                               Value = ((int)ft).ToString(),
                               Text = ft.ToString()
                           }), "Value", "Text");
        }

        public async Task<IActionResult> OnPost()
        {

            Specialist.Id = Guid.NewGuid();
            Specialist.CreatorId = CurrentUserId;
            Specialist.CreationDate = DateTime.UtcNow;

            var newuser = new User
            {
                Id = Guid.NewGuid(),
                Name = Specialist.Fullname,
                Email = Specialist.Email.ToLower().Trim(),
                LoginId = Specialist.Email.ToLower().Trim(),
                CreationDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                IsActive = true,
                IsEmailConfirmed = true,
               
                ActivationDate = DateTime.Now,
                
                SpecialistId = Specialist.Id,


            };
            await Db.User.AddAsync(newuser);
            newuser.PasswordHash = _userManager.PasswordHasher.HashPassword(newuser, "Specialist");
            await Db.Specialist.AddAsync(Specialist);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { Specialist.Id });
        }
    }

}


