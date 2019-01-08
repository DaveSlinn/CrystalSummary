using CrystalReportConversionSummary.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crystal_Report_Conversion_Summary.Pages
{
    public class ReportsNotCalled : PageModel
    {
        public IList<ReportRun> ReportsNotInUse { get; set; }

        public async Task OnGetAsync()
        {
            ReportsNotInUse = (await SandboxData.GetSprocNotInUseAsync()).ToList();
        }
    }
}
