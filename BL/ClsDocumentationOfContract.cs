using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface DocumentationOfContractService
    {
        List<TbDocumentationOfContract> getAll();
        bool Add(TbDocumentationOfContract client);
        bool Edit(TbDocumentationOfContract client);
        bool Delete(TbDocumentationOfContract client);


    }
    public class ClsDocumentationOfContract : DocumentationOfContractService
    {
        AlMohamyDbContext ctx;

        public ClsDocumentationOfContract(AlMohamyDbContext context)
        {
            ctx = context;
        }
        public List<TbDocumentationOfContract> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbDocumentationOfContract> lsDocumentationOfContract = ctx.TbDocumentationOfContracts.ToList();

            return lsDocumentationOfContract;
        }

        public bool Add(TbDocumentationOfContract item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbDocumentationOfContracts.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbDocumentationOfContract item)
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

        public bool Delete(TbDocumentationOfContract item)
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
