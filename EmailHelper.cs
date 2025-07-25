using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


public static class EmailHelper
{
    // 邮件服务器配置（建议放在配置文件中）
    private static readonly string SmtpServer = "smtp.qq.com"; // 以163邮箱为例
    private static readonly int SmtpPort = 587;
    private static readonly string FromEmail = "88595311@qq.com";
    private static readonly string FromPassword = "kllirtuiunqycaid"; // 或授权码

    public static bool SendVerificationEmail(string toEmail, string verificationCode)
    {
        try
        {
            using (SmtpClient smtp = new SmtpClient(SmtpServer, SmtpPort))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(FromEmail, FromPassword);

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(FromEmail),
                    Subject = "密码重置验证码",
                    Body = $"您的验证码是: {verificationCode}，15分钟内有效。\n\n请勿将此代码透露给他人。",
                    IsBodyHtml = false
                };
                mail.To.Add(toEmail);

                smtp.Send(mail);
                return true;
            }
        }
        catch (Exception ex)
        {
            // 实际项目中应该记录日志
            Console.WriteLine($"邮件发送失败: {ex.Message}");
            return false;
        }
    }
}
