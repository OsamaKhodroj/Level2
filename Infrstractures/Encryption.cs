namespace Infrstractures;

public class Encryption
{ 
    /// <summary>
    /// this method is used to hash a given text using BCrypt hashing algorithm.
    /// </summary>
    /// <param name="text"></param> 
    public static string Hash(string text)
    {
        try
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("Text data is required");

            var result = BCrypt.Net.BCrypt.HashPassword(text);
            return result;
        }
        catch (Exception)
        {

            throw;
        }
    }
     
    /// <summary>
    /// This method verifies if a given text matches a previously hashed value using BCrypt.
    /// </summary> 
    public static bool Verify(string text, string hash)
    {
        try
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("Text data is required");
            if (string.IsNullOrEmpty(hash))
                throw new ArgumentNullException("Hash data is required");

            var result = BCrypt.Net.BCrypt.Verify(text, hash);
            return result;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
