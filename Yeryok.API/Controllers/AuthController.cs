using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Yeryok.API.Data;
using Yeryok.API.Helpers;
using Yeryok.Shared.Entities;
using Yeryok.Shared.Model.RequestModels;
using Yeryok.Shared.Model.ResponseModels;

namespace Yeryok.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public AuthController(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginRequestModel loginRequestModel)
        {
            var user = context.Users.SingleOrDefault(x => x.Email == loginRequestModel.LoginKey || x.UserName == loginRequestModel.LoginKey && x.Password == loginRequestModel.Password);
            if (user == null)
                return BadRequest("Kullanıcı Bulunamadı");

            //TOKEN OLUŞTURDUK 

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ASdASD465465465XZXCAS");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseModel loginResponseModel = mapper.Map<LoginResponseModel>(user);
            loginResponseModel.Token = tokenHandler.WriteToken(token);   // yakaladığı token ı loginresponsemodelteki token a yazdı

            return Ok(loginResponseModel);
        }


        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestModel registerRequestModel)
        {
            var newEmailUser = await context.Users.FirstOrDefaultAsync(s => s.Email == registerRequestModel.Email);

            if (newEmailUser != null)
                return BadRequest("Bu mail adresi kullanılmaktadır");
            if (newEmailUser is null)
            {
                newEmailUser = mapper.Map<Shared.Entities.User>(registerRequestModel);
                await context.Users.AddAsync(newEmailUser);
                await context.SaveChangesAsync();
            }
            LoginResponseModel responseModel = mapper.Map<LoginResponseModel>(newEmailUser);
            return Ok(responseModel);
        }
        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestModel forgotPasswordRequestModel)
        {
            var mail = await context.Users.FirstOrDefaultAsync(a => a.Email == forgotPasswordRequestModel.Email);
            if (mail is null)
                return BadRequest("Mail Bulunamadı");

            mail.Password = GeneratePassword(6);
            context.Users.Update(mail);
            await context.SaveChangesAsync();
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("s.ozkan0041@gmail.com", "No052959");


            MailAddress mailAddress = new MailAddress("s.ozkan0041@gmail.com"); // gönderiyorum
            MailAddress to = new MailAddress(forgotPasswordRequestModel.Email); // gönderiliyor
            MailMessage message = new MailMessage(mailAddress, to);
            message.Body = "Your New Password:" + mail.Password;

            string userState = "Test Message";
            client.SendAsync(message, userState);


            Console.WriteLine("Sending message");

            return Ok(mail);
        }


        private string GeneratePassword(int length)
        {
            //random şifre üreten fonk

            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}