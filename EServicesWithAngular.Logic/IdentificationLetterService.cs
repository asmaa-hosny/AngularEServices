using ERB_IdentificationLetter;
using EServicesWithAngular.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.Logic
{
    public class IdentificationLetterService
    {
         public static long SaveNew(IdentificationLetter identificationLetter)
        {
            LetterRequestServiceClient client = new LetterRequestServiceClient();
            letterRequest letter = new letterRequest();
            letter.employeeid = (int)identificationLetter.EmployeeID;
            letter.documentno = identificationLetter.REF_ID;
            letter.id = identificationLetter.RequestNo;
            letter.SIGNATURETYPE = identificationLetter.SignatureType;
            letter.doctypeid = identificationLetter.RequestType;
            long toBeReturned = client.saveNewLetterRequestAsync(letter).GetAwaiter().GetResult().result.letterrequest.id;
            return toBeReturned;
        }

        public static void findOne(string jobId,IdentificationLetter identificationLetter)
        {
            LetterRequestServiceClient client = new LetterRequestServiceClient();       
            var letter = client.findByJobIdAsync(jobId).GetAwaiter().GetResult().letterrequest;
            identificationLetter.EmployeeID = letter.employeeid;
            letter.documentno = identificationLetter.REF_ID;
            identificationLetter.RequestNo=letter.id;
            identificationLetter.SignatureType = letter.SIGNATURETYPE;
            identificationLetter.RequestType = letter.doctypeid;
        }


        public static void updateKtaJobId(long requestNo, string jobID)
        {
            LetterRequestServiceClient client = new LetterRequestServiceClient();
            client.updateKtaJobIdAsync(requestNo, jobID).GetAwaiter().GetResult();
        }
    }
}
