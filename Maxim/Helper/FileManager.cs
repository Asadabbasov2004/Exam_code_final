namespace Maxim.Helper
{
    public static class FileManager
    {
        public static bool CheckType(this IFormFile file,string type)
        {
            return file.ContentType.Contains("/image");
        }
        public static bool CheckLength(this IFormFile file,int length)
        {
            return file.Length / 1024 / 1024 <= 3;
        }
        public static string Upload(this IFormFile file, string envPath, string folderName)
        {
            string filname = file.FileName; if (filname.Length > 64) { filname = filname.Substring(filname.Length - 64); }
            filname = Guid.NewGuid().ToString() + filname;

            string path = envPath + folderName + filname;
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return filname;
        }
       

    }
}