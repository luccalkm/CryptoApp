using System.Security.Cryptography;

namespace CriptografiaApp.Servicos;

public class CryptoService
{
    private readonly Aes _aes;
    private readonly ICryptoTransform _cryptoTransform;
    private readonly ICryptoTransform _decryptoTransform;

    public CryptoService()
    {
        _aes = Aes.Create();
        _aes.GenerateKey();
        _aes.GenerateIV();

        _cryptoTransform = _aes.CreateEncryptor(_aes.Key, _aes.IV);
        _decryptoTransform = _aes.CreateDecryptor(_aes.Key, _aes.IV);
    }


    public string Encrypt(string plainText)
    {
        using (var ms = new MemoryStream())
        {
            using (var cs = new CryptoStream(ms, _cryptoTransform, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }
        
    }

    public string Decrypt(string cipherText)
    {
        var cipherBytes = Convert.FromBase64String(cipherText);

        using (var ms = new MemoryStream(cipherBytes))
        using (var cs = new CryptoStream(ms, _decryptoTransform, CryptoStreamMode.Read))
        using (var sr = new StreamReader(cs))
        {
            return sr.ReadToEnd();
        }
    }
}