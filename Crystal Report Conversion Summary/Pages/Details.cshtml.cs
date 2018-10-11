using CrystalReportConversionSummary.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crystal_Report_Conversion_Summary.Pages
{
    public class DetailsModel : PageModel
    {
        public string ReportName { get; set; }

        public IList<ReportDetail> ReportDetails { get; set; }

        public async Task OnGetAsync(int id, string name)
        {
            ReportName = name;

            ReportDetails = (await SandboxData.GetSprocHistoryDetailAsync(id)).ToList();
        }
    }
}