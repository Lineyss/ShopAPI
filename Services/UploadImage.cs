using System.Text;

namespace ShopAPI2.Services
{
    public class UploadImage
    {
        private string PathToFile = null;
        private string path = "~/StaticFiles/";
        public async void Upload(IFormFile file)
        {
            if (file == null)
                throw new Exception("Файл пустой");

            PathToFile = path + RandomFileName(Path.GetExtension(file.FileName));

            if (File.Exists(PathToFile))
                PathToFile += "1";

            using (var strem = new FileStream(PathToFile, FileMode.Create))
            {
                await file.CopyToAsync(strem);
            }

        }

        private string RandomFileName(string FilePath)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder stringBuilder = new StringBuilder(15);

            for (int i = 0; i < 15; i++)
            {
                stringBuilder.Append(chars[random.Next(chars.Length)]);
            }

            string randomString = stringBuilder.ToString();
             
            return randomString + FilePath;
        }

        public string GetUploadingFile()
        {
            while(PathToFile == null)
            {
                Task.Delay(100);
            }

            return PathToFile;
        }
    }
}
