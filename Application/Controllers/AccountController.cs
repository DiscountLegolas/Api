using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Model.AccountController;
using Castle.Core.Smtp;
using Data.EFCore.Classes;
using FluentEmail.Core;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager , RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("User")]
        public async Task<ActionResult> UserCreate([FromBody] UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.UserName.Trim(),
                    Email = model.Email.Trim()
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password.Trim());
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("User").Result)
                    {
                        ApplicationRole role = new ApplicationRole()
                        {
                            Name="User"
                        };
                        IdentityResult roleResult = await _roleManager.CreateAsync(role);
                        if (roleResult.Succeeded)
                        {
                            _userManager.AddToRoleAsync(user, "User").Wait();
                        }
                    }
                    _userManager.AddToRoleAsync(user, "User").Wait();
                    return Ok();
                }
                String errorMessage = String.Empty;
                foreach (var item in result.Errors)
                {
                    errorMessage += item.Description;
                }
                return BadRequest(errorMessage);
            }
            return BadRequest("Bilgilerinizi kontrol ediniz. İstenilen formatta değil");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(model.EMail.Trim());
                if (user!=null && await _userManager.CheckPasswordAsync(user,model.Password.Trim()))
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };

                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916"));

                    var token = new JwtSecurityToken(
                        issuer:"http://google.com",
                        audience:"http://google.com",
                        expires:DateTime.UtcNow.AddDays(1),
                        claims:claims,
                        signingCredentials:new SigningCredentials(signinKey,SecurityAlgorithms.HmacSha256)
                        );
                    return Ok(new {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                else
                {
                    return BadRequest("Giriş bilgilerinizi kontrol edin hatalı gözüküyor.");
                }
            }
            return BadRequest("Veriler uygun değil");
        }
        [HttpPost]
        [Route("Forgot")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model İs Not Valid");
            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
                return BadRequest(BadRequest("Model İs Not Valid"));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = "http://localhost:3000/Reset?token=" + token + "&email=" + user.Email;
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("aykutalpozgur@hotmail.com");
            message.To.Add(new MailAddress(forgotPasswordModel.Email));
            message.Subject = "Test";
            string body = string.Format("<h2>Password Reset Request for Your Account</h2>" +
                "<p>We recently received a request to reset your password for your account. If you did not request this, please disregard this email.</p>" +
                "<p>To reset your password, click on the link below:</p>\r\n" +
                "<p><a href=\"{0}\" style=\"background-color: #4CAF50; color: white; padding: 10px 20px; text-decoration: none; border-radius: 4px;\">Reset Password</a></p>" +
                "<p>This link will expire in 15 minutes for security reasons. If the link has expired, please request a new password reset.</p>" +
                "<p>If you are having trouble with the link, you can copy and paste the following URL into your browser:</p>" +
                "<p>{0}</p>", callback);
            message.Body = body;
            smtp.Port = 587;
            message.IsBodyHtml = true;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("aykutalpozgur@hotmail.com", "Ozgur1998");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
            return Ok();
        }
        [HttpPost]
        [Route("Reset")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model İs Not Valid");

            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
               return  BadRequest(BadRequest("Model İs Not Valid"));

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}