using Proje.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Business
{
    public class PagingForAllDatas
    {

        public IEnumerable CreatePagingButtons(List<USERS> list, int pagenumber_)
        {
            int pagecount_ = list.Count / 10;
            if (pagecount_ % 10 > 0)
            {
                pagecount_ += 1;
            }
            List<string> pages_ = new List<string>();
            var pages = pages_;

            for (int i = 1; i < pagecount_ + 1; i++)
            {
                pages.Add(i.ToString());
            }

            if (pagenumber_ < 5)
            {
                return pages.Take(10);
            }
            else
            {
                return pages.Skip(pagenumber_ - 4).Take(10);
            }
        }
    }
}
