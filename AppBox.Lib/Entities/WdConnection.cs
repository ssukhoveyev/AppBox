using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppBox.Lib.Entities
{
    public class WdConnection
    {
        public string name;
        public string connectionString;
        public WdConnection(DataRow dr)
        {
            this.name = dr["name"].ToString();

            string database = dr["base"].ToString();
            string uid = dr["user"].ToString();
            string host = dr["host"].ToString();
            
            string server = dr["server"].ToString();
            if (!String.IsNullOrEmpty(server))
                host += @"\" + server;

            string pwd = Encoding.UTF8.GetString(EnCrypt((byte[])dr["password"]));

            connectionString = $"uid={uid};pwd={pwd};MultipleActiveResultSets=True;database={database};server={host};Connection Timeout = 10;";

            //Console.WriteLine(Encoding.UTF8.GetString(Crypt("WinDraw2018")));
        }

        public static byte[] EnCrypt(byte[] val)
        {
            byte[] Key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

            RijndaelManaged RMCrypto = new RijndaelManaged();
            MemoryStream ms = new MemoryStream(val);
            CryptoStream CryptStream = new CryptoStream(ms, RMCrypto.CreateDecryptor(Key, IV), CryptoStreamMode.Read);
            StreamReader SReader = new StreamReader(CryptStream);

            string s = SReader.ReadToEnd();
            SReader.Close();
            CryptStream.Close();
            ms.Close();

            return System.Text.Encoding.Default.GetBytes(s);
        }

        public static byte[] Crypt(object val)
        {
            byte[] Key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            byte[] IV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

            RijndaelManaged RMCrypto = new RijndaelManaged();
            MemoryStream ms = new MemoryStream();
            CryptoStream CryptStream = new CryptoStream(ms, RMCrypto.CreateEncryptor(Key, IV), CryptoStreamMode.Write);
            StreamWriter SWriter = new StreamWriter(CryptStream);
            if (val is byte[])
                SWriter.Write(System.Text.Encoding.Default.GetString((byte[])val));
            else
                SWriter.Write(val);

            SWriter.Close();
            CryptStream.Close();
            ms.Close();
            return Get(ms.GetBuffer());
        }

        public static byte[] Get(byte[] input)
        {
            string s = System.Text.Encoding.Default.GetString(input).TrimEnd('\0');
            if (s.Length % 16 != 0)
                s = s.PadRight((s.Length / 16 + 1) * 16, '\0');
            return System.Text.Encoding.Default.GetBytes(s);
        }
    }
}
