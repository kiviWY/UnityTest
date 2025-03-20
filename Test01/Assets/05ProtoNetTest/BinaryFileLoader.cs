using System.IO;
using System.Threading.Tasks;
using ProtoBuf;
using UnityEngine;

namespace Example_05
{


    public class BinaryFileLoader 
    {
        
        private readonly string path = Application.persistentDataPath ;



        public async Task<T> LoadData<T>()
        {
            string fileName = typeof(T).Name + ".dat";
            byte[] bytes = await ReadFileAsync(fileName);
            T data = DeserializeData<T>(bytes);
            return data;
        }



        private async Task<byte[]> ReadFileAsync(string path)
        {
            string fullPath = Path.Combine(this.path, path);
            using (FileStream stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read,
                       bufferSize: 4096, useAsync: true))
            {
                byte[] buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, (int)stream.Length);
                return buffer;
            }
        }

        private T DeserializeData<T>(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                var data = Serializer.Deserialize<T>(stream);
                return data;
            }
        }
    }
}