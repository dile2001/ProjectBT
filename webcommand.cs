using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TcpComm;


namespace RecloserAcq.Device
{
    public class webcommand : RecloserBase
    {
        public webcommand(int port)
            : base(port)
        {
        }

        public webcommand()
            : base()
        { 
        }
        public int IDControl = -11111111;
        public string commandstr = string.Empty;
        public string UserID = string.Empty;
        public string commandpassword = string.Empty;
        public override void UpdateData(byte[] data)
        {
            int i = 0;
            //UserID_DeviceID_DONG_Password\r\n
            try
            {
                string reply = Ultility.GetAsciiString(data);
                string[] strs = reply.Split('_');
                IDControl = Convert.ToInt32(strs[2]);
                commandstr = strs[3];
                UserID = strs[1];
                commandpassword = strs[4];
                FA_Accounting.Common.LogService.WriteInfo("UpdateData", strs[1] + strs[2] + strs[3] + strs[4]);
            }
            catch (Exception ex)
            {
                FA_Accounting.Common.LogService.WriteInfo("Webcommand",ex.ToString());
            }
            
            base.UpdateData(data);
            
        }
    }
}
