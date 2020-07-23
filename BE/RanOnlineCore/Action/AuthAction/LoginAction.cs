using Dapper.FastCrud;
using Framework;
using RanOnlineCore.Entity;
using RanOnlineCore.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RanOnlineCore.Action.AuthAction
{
    public class LoginAction : CommandBase<dynamic>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        private string NotCorrect =  "Tài khoản hoặc mật khẩu không đúng!";
        protected override void ValidateCore(ObjectContext context)
        {
            if(this.Username == null || this.Password == null)
            {
                throw new BadRequestException(this.NotCorrect);
            }
        }
        protected override void OnExecutingCore(ObjectContext context)
        {
            this.Password = context.MD5Encode(this.Password,19);
        }
        private UserInfo GetUser(ObjectContext context)
        {
            return context.RanUser.Find<UserInfo>(state => state
                .Where($"UserName = @Username")
                .Where($"UserPass = @Password")
                .WithParameters(new { this.Username, this.Password })
                ).FirstOrDefault();
        }
        private User GetRoleUser(ObjectContext context, long userId)
        {
            return context.RanMaster.Get(new User { Id = userId });
        }
        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            var user = this.GetUser(context);
            if (user == null) {
                throw new BadRequestException(NotCorrect);
            }
            
            var token = context.Encrypt(new UserAuth
            {
                UserId = user.UserNum,
                Username = user.UserName,
                Expired = context.CreateExpired()
            });
            return Success(new {
                token
            });
        }
    }
}
