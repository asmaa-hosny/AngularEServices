using EServicesWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Exceptions
{
    public class EntityNotFoundException : CustomException
    {
        public BaseModel Entity { get; set; }
        public new string FriendlyMsgAR => $" لم يتم العثور على : {Entity.ID} من نوع: {Entity.TypeAR} ";
        public new string FriendlyMsgEN => $"{Entity.TypeEN} with ID: {Entity.ID} was not found";
    }
}