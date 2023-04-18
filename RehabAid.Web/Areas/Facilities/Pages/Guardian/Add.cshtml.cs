using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RehabAid.Data;
using RehabAid.Web.Pages;

namespace RehabAid.Web.Areas.Facilities.Pages.Guardian
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
        public Guardians Guardian { get; set; }

        public SelectList TreatmentFacilities { get; set; }
        public SelectList Patients { get; set; }


        public void OnGet()
        {
            Title = PageTitle = "Add new ";
            TreatmentFacilities = new SelectList(Db.TreatmentFacility, nameof(TreatmentFacility.Id), nameof(TreatmentFacility.Name));
            Patients = new SelectList(Db.Patient, nameof(Patient.Id), nameof(Patient.FirstName));

        }
        public async Task<IActionResult> OnPost()
        {
            Guardian.Id = Guid.NewGuid();
            var newuser = new User
            {
                Id = Guid.NewGuid(),
                Name = Guardian.Fullname,
                Email = Guardian.Email.ToLower().Trim(),
                LoginId = Guardian.Email.ToLower().Trim(),
                CreationDate = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString(),
                IsActive = true,
                IsEmailConfirmed = true,

                ActivationDate = DateTime.Now,

                GuardianId = Guardian.Id,


            };

            await Db.User.AddAsync(newuser);
            newuser.PasswordHash = _userManager.PasswordHasher.HashPassword(newuser, "Guardian");
            await Db.Guardians.AddAsync(Guardian);
            await Db.SaveChangesAsync();
            return RedirectToPage("./Details", new { Guardian.Id }); 

        }
    }
}
