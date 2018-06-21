using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaawonMVC.Models
{
  public  class UsesOfBuilding : FullAuditedEntity
    {
        public UsesOfBuilding()
        {
            CreationTime = Clock.Now;
            usedFor = "";
            IsDeleted = false;

        }

        [Required]
         public string usedFor { get; set; }
    }
}
