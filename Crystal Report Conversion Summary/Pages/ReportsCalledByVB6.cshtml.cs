using CrystalReportConversionSummary.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crystal_Report_Conversion_Summary.Pages
{
    public class ReportsCalledByVB6 : PageModel
    {
        public IList<ReportRun> ReportsByVB6 { get; set; }

        public async Task OnGetAsync()
        {
            ReportsByVB6 = (await SandboxData.GetSprocHistoryAsyncCalledByVB6()).ToList();
        }
    }
}
