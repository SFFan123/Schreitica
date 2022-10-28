using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DeviceId;

namespace Schreitica
{
    public static class CryptHelper
    {
        public static string Encrypt(string clearText)
        {
            string EncryptionKey =new DeviceIdBuilder()
                    .AddMachineName()
                    .AddOsVersion()
                    .OnWindows(windows => windows
                        .AddProcessorId()
                        .AddMotherboardSerialNumber()
                        .AddSystemDriveSerialNumber())
                    .ToString();
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 84,119,105,116,99,104,32,80,114,105,109,101,32,105,115,32,110,111,116,32,97,32,99,114,105,109,101,46 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static SecureString Decrypt(string cipherText)
        {
            string EncryptionKey =new DeviceIdBuilder()
                .AddMachineName()
                .AddOsVersion()
                .OnWindows(windows => windows
                    .AddProcessorId()
                    .AddMotherboardSerialNumber()
                    .AddSystemDriveSerialNumber())
                .ToString();
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            var res = new SecureString();
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 84,119,105,116,99,104,32,80,114,105,109,101,32,105,115,32,110,111,116,32,97,32,99,114,105,109,101,46 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    var chars = Encoding.Unicode.GetString(ms.ToArray()).ToCharArray();
                    foreach (char c in chars)
                    {
                        res.AppendChar(c);
                    }
                    chars = Array.Empty<char>();
                }
            }
            return res;
        }
    }

    public static class SettingHelper
    {
        public static void SaveSetting(string settingXML)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Schreitica");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path = Path.Combine(path, "Settings.xml");

            File.WriteAllText(path, settingXML, Encoding.UTF8);
        }

        public static FileStream LoadSettings()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Schreitica", "Settings.xml");

            if (!File.Exists(path))
                return null;

            return File.OpenRead(path);
        }
    }
}
