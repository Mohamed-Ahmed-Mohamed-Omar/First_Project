namespace First_Project.BL.Helper
{
    public static class UploadFileHelper
    {
        public static string SaveFile(IFormFile FileUrl, string FoloderPath)
        {

            // Get Directory
            string FilePath = Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FoloderPath;

            // Get File Name
            string FileName = Guid.NewGuid() + Path.GetFileName(FileUrl.FileName); // to avoid the token and replace

            // Merge The Directory With File Name 
            string FinalPath = Path.Combine(FilePath , FileName);

            // Save Your File As Stream "Data Overtime" 
            using (var Stream = new FileStream(FinalPath, FileMode.Create))
            {
                FileUrl.CopyTo(Stream);
            }

            return FileName;
        }

        public static void RemoveFile(string FolderName, string RemoveFileName)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "wwwroot/Files/" + FolderName + RemoveFileName))
            {
                File.Delete(Directory.GetCurrentDirectory() + "wwwroot/Files/" + FolderName + RemoveFileName);
            } 
        }
    }
}
