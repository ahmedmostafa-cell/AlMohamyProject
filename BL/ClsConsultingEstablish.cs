using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ConsultingEstablishService
    {
        List<TbConsultingEstablish> getAll();
        bool Add(TbConsultingEstablish client);
        bool Edit(TbConsultingEstablish client);
        bool Delete(TbConsultingEstablish client);


    }
    public class ClsConsultingEstablish : ConsultingEstablishService
    {
        AlMohamyDbContext ctx;

        public ClsConsultingEstablish(AlMohamyDbContext context)
        {
            ctx = context;
        }
        public List<TbConsultingEstablish> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbConsultingEstablish> lstConsultingEstablishs = ctx.TbConsultingEstablishes.ToList();

            return lstConsultingEstablishs;
        }

        public bool Add(TbConsultingEstablish item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbConsultingEstablishes.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbConsultingEstablish item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbConsultingEstablish item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
