using Newtonsoft.Json;
using System;
using System.IO;

namespace MatrixCore
{
    public static class MatrixSerializer
    {                
        public static void Serialize(Matrix matrix, string filePath)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.Default))
                {
                    string serialized = JsonConvert.SerializeObject(matrix, Formatting.Indented);
                    sw.WriteLine(serialized);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot serialize\n" + ex.Message);
            }
            

        }
        public static Matrix Deserialize(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string data = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<Matrix>(data);
                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Cannot deserialize\n" + ex.Message);
                return null;
            }
        }
    }
}
