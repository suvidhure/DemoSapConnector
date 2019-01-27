using SAP.Middleware.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSapConnector
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        private static RfcDestination connectSAP()
        {
            RfcDestination SapRfcDestination = RfcDestinationManager.GetDestination("rfc");
            return SapRfcDestination;
        }
        private static void GetInvoiceBillingData()
        {
            RfcDestination sapRfc = connectSAP();
            RfcSessionManager.BeginContext(sapRfc);

            IRfcFunction funcInvHdrs = sapRfc.Repository.CreateFunction("");
            funcInvHdrs.SetValue("IV_BELNR", "");
            funcInvHdrs.Invoke(sapRfc);

            IRfcTable tblRfcInvHdr = funcInvHdrs.GetTable("ET_OUTTAB");
            for (int i=0;i<tblRfcInvHdr.Count;i++)
            {
                Console.WriteLine(tblRfcInvHdr[i].GetValue("BELNR"));
            }

        }
    }
}
