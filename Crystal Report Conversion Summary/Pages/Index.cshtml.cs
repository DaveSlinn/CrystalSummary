using CrystalReportConversionSummary.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crystal_Report_Conversion_Summary.Pages
{
    public class IndexModel : PageModel
    {
        public IList<ReportRun> Reports { get; set; }

        public async Task OnGetAsync()
        {
            Reports = (await SandboxData.GetSprocHistoryMasterAsync()).ToList();
        }
    }
}
