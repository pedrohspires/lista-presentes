using System.Security.Cryptography;
using System.Text;

namespace lista_presentes.Utils
{
    public static class Hash
    {
        public static Guid GetUUIDHashCode(int id)
        {
            using var sha1 = SHA1.Create();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(id.ToString()));

            // Pega os primeiros 16 bytes do hash para formar um GUID
            byte[] guidBytes = new byte[16];
            Array.Copy(hash, guidBytes, 16);

            return new Guid(guidBytes);
        }
    }
}
