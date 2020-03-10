using CrystalReportConversionSummary.Classes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crystal_Report_Conversion_Summary.Pages
{
    public class RunHistoryModel : PageModel
    {
        public string ReportName { get; set; }

        public string UserName { get; set; }

        public IList<RunHistoryItem> RunHistory { get; set; }

        public async Task OnGetAsync(int id, string name, string user)
        {
            ReportName = name;
            UserName = user;

            RunHistory = (await SandboxData.GetSprocRunHistoryAsync(id, user)).ToList();
        }
    }
}