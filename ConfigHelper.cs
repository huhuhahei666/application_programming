using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
public static class ConfigHelper
{
    private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("nfj/WUxfV6b90JA3OfC1IA=="); // 修改为你的唯一盐值

    public static void SaveCredentials(string username, string password, bool rememberMe)
    {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        config.AppSettings.Settings["LastUser"].Value = rememberMe ? username : "";
        config.AppSettings.Settings["EncryptedPassword"].Value = rememberMe ? EncryptString(password) : "";
        config.AppSettings.Settings["RememberMe"].Value = rememberMe.ToString();

        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("appSettings");
    }

    public static (string Username, string Password, bool RememberMe) LoadCredentials()
    {
        try
        {
            // 安全获取配置值（避免null引用）
            string user = ConfigurationManager.AppSettings["LastUser"] ?? "";
            string encPwd = ConfigurationManager.AppSettings["EncryptedPassword"] ?? "";

            // 安全解析布尔值
            bool remember = false;
            bool.TryParse(ConfigurationManager.AppSettings["RememberMe"], out remember);

            // 仅在需要时解密（减少攻击面）
            string password = "";
            if (remember && !string.IsNullOrEmpty(encPwd))
            {
                try
                {
                    password = DecryptString(encPwd);
                }
                catch (CryptographicException ex)
                {
                    // 记录解密失败（实际项目应使用日志框架）
                    Debug.WriteLine($"解密失败: {ex.Message}");
                    remember = false; // 自动禁用记住我状态
                }
            }

            return (user, password, remember);
        }
        catch (Exception ex)
        {
            // 全局异常处理（建议实际项目记录日志）
            Debug.WriteLine($"加载配置异常: {ex.Message}");
            return ("", "", false); // 返回安全默认值
        }
    }

    private static string EncryptString(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        byte[] encrypted = ProtectedData.Protect(
            Encoding.UTF8.GetBytes(input),
            Entropy,
            DataProtectionScope.CurrentUser);

        return Convert.ToBase64String(encrypted);
    }

    private static string DecryptString(string encrypted)
    {
        if (string.IsNullOrEmpty(encrypted)) return "";

        byte[] decrypted = ProtectedData.Unprotect(
            Convert.FromBase64String(encrypted),
            Entropy,
            DataProtectionScope.CurrentUser);

        return Encoding.UTF8.GetString(decrypted);
    }
}