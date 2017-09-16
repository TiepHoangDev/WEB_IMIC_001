using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class ExperiencerDao : BaseModel<ExperiencerObject>
    {
        /*
        * DAO Experiencer
        * NgocNB - 10102016
        */

        //private static WebIMicEntities m_objDb = new WebIMicEntities();

        /*
         * Lấy all chuyên gia
         * NgocNB - 10102016
        */
        public override List<ExperiencerObject> getAllElements()
        {
            List<ExperiencerObject> lisRs = new List<ExperiencerObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_Experiencer_GetAll().ToList();



                foreach (var o in lisGet)
                {
                    lisRs.Add(new ExperiencerObject
                    {
                        ExperiencerId = o.ExperiencerId,
                        Address = o.Address,
                        CompanyName = o.CompanyName,
                        Email = o.Email,
                        ExperiencerImage = o.ExperiencerImage,
                        ExperienceYear = o.ExperienceYear,
                        FullName = o.FullName,
                        Gender = o.Gender,
                        ModifiedBy = o.ModifiedBy,
                        ModifiedTime = o.ModifiedTime,
                        PassageDescription = o.PassageDescription,
                        Phone = o.Phone,
                        RankToShowIntroduce = o.RankToShowIntroduce,
                        SummaryContent = o.SummaryContent
                    });
                }
            }
            

            return lisRs;
        }

        public List<ExperiencerObject> GetExperiencerByCourseId(Guid courseId)
        {
            List<ExperiencerObject> lisRs = new List<ExperiencerObject>();
            using (var dbContext = new WebIMicEntities())
            {
                var lisGet = dbContext.WEB_IMIC_SP_Experiencer_GetAllByCourseId(courseId).ToList();
                
                foreach (var o in lisGet)
                {
                    ExperiencerObject objEO = new ExperiencerObject();
                    objEO.ExperiencerId = o.ExperiencerId;
                    objEO.Address = o.Address;
                    objEO.CompanyName = o.CompanyName;
                    objEO.Email = o.Email;
                    objEO.ExperiencerImage = o.ExperiencerImage;
                    objEO.ExperienceYear = o.ExperienceYear;
                    objEO.FullName = o.FullName;
                    objEO.Gender = o.Gender;
                    objEO.ModifiedBy = o.ModifiedBy;
                    objEO.ModifiedTime = o.ModifiedTime;
                    objEO.PassageDescription = o.PassageDescription;
                    objEO.Phone = o.Phone;
                    objEO.RankToShowIntroduce = o.RankToShowIntroduce;
                    objEO.SummaryContent = o.SummaryContent;

                    lisRs.Add(objEO);
                }
            }

            return lisRs;
        }

        public bool ExperiencerInsert(ExperiencerObject objEx)
        {
            using (var db = new WebIMicEntities())
            {
                db.WEB_IMIC_SP_Experiencer_Update(
                    Guid.NewGuid(),
                    objEx.RankToShowIntroduce,
                    objEx.ExperiencerImage,
                    objEx.FullName,
                    objEx.Gender,
                    objEx.Phone,
                    objEx.Email,
                    objEx.Address,
                    objEx.ExperienceYear,
                    objEx.CompanyName,
                    objEx.PassageDescription,
                    objEx.ModifiedBy,
                    DateTime.Now,
                    false,
                    objEx.SummaryContent,
                    false);
            }

            return true;
        }
    }
}
