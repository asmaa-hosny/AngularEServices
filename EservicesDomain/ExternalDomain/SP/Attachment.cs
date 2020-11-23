using System;
 

namespace EservicesDomain.ExternalDomain.SP
{
    public class Attachment 
    {
        public Attachment(String FileName, String FileID, String UploaderName, DateTime UploadDate, String ActivityName, String FileAbsolutePath, string type = "")
        {

            this.FileName = FileName;
            this.FileID = FileID;
            this.UploaderName = UploaderName;
            this.UploadDate = UploadDate;
            this.ActivityName = ActivityName;
            this.FileAbsolutePath = FileAbsolutePath;
            this.Type = type;
        }
        public String FileName { get; set; }
        public String FileID { get; set; }
        public String UploaderName { get; set; }
        public DateTime UploadDate { get; set; }
        public String ActivityName { get; set; }
        public String FileAbsolutePath { get; set; }
        public String Type { get; set; }




    }
}
