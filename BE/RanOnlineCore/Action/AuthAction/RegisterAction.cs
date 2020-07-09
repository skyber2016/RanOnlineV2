using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.AuthAction
{
    public class RegisterAction : CommandBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        private string Password2 { get; set; }
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.Username == null || this.Password == null)
            {
                throw new BadRequestException();
            }
            if(this.Username.Length < 4 || this.Username.Length > 16)
            {
                throw new BadRequestException("Tài khoản phải lớn hơn 4 và nhỏ hơn 16 ký tự");
            }
            if(this.Password.Length < 4 || this.Password.Length > 14)
            {
                throw new BadRequestException("Mật khẩu phải lớn hơn 4 và nhỏ hơn 14 ký tự");

            }
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            this.Password2 = context.MD5Encode(this.Password);
            this.Password = context.MD5Encode(this.Password, 19);
        }
        private UserInfo GetUser(ObjectContext context)
        {
            return context.RanUser.Find<UserInfo>(state =>
                state.Where($"UserName = @Username")
                .WithParameters(new { this.Username })
            ).FirstOrDefault();
        }
        private UserInfo Insert(ObjectContext context,UserInfo user)
        {
            context.RanUser.Insert(user);
            return user;
        }
        protected override Result ExecuteCore(ObjectContext context)
        {
            var user = this.GetUser(context);
            if(user != null)
            {
                throw new BadRequestException("Tài khoản này đã có người sử dụng");
            }
            user = new UserInfo
            {
                UserName = this.Username,
                UserPass = this.Password,
                UserID = this.Username,
                UserPass1 = this.Password,
                UserPass2 = this.Password,
                UserEmail = this.Username + "@gmail.com",
                CreateDate = DateTime.Now,
                LastLoginDate = DateTime.Now,
                PremiumDate = new DateTime(1970, 02, 01),
                ChatBlockDate = new DateTime(1970, 02, 01),
                OfflineTime = new DateTime(1905, 05,  22),
                GameTime = new DateTime(1905, 05,  22),
                UserBlockDate = DateTime.Now,
                UserType = 1
            };
            user = this.Insert(context, user);
            return Success();
        }
    }
}
